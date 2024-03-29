﻿using AutoMapper;
using Exercice05.DTOs;
using Exercice05.Models;
using Exercice05.Repositories;
using Exercice05.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Exercice05.Controllers
{

    [Route("users")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IRepository<User> _repository;
        private readonly IMapper _mapper;

        public UserController(IRepository<User> repository,
                                 IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET /contacts
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //return Ok(_repository.GetAll());
            IEnumerable<User> users = await _repository.GetAll();

            IEnumerable<UserDTO> userDTOs = _mapper.Map<IEnumerable<UserDTO>>(users)!;
            //IEnumerable<ContactDTO> contactDTOs = _mapper.Map<IEnumerable<Contact>, IEnumerable<ContactDTO>>(contacts)!;

            // possible d'ajouter des modification par rapport aux DTOs ici

            return Ok(userDTOs);
        }

        //GET /contacts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _repository.Get(id);

            if (user == null)
                return NotFound(new
                {
                    Message = "There is no User with this Id."
                });

            UserDTO userDTO = _mapper.Map<UserDTO>(user)!;

            return Ok(new
            {
                Message = "User found.",
                Contact = userDTO
            });
        }

        //POST /contacts
        [HttpPost]
        [Authorize(Roles = Constants.RoleAdmin)]
        public async Task<IActionResult> Post([FromBody] UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO)!;

            var userAdded = await _repository.Add(user);

            var userAddedDTO = _mapper.Map<UserDTO>(userAdded)!;

            if (userAdded != null)
                return CreatedAtAction(nameof(GetById), 
                                       new { id = userAddedDTO.Id },
                                       new
                                       {
                                            Message = "User Added.",
                                            Contact = userAddedDTO
                                       });

            return BadRequest("Something went wrong...");
        }

        //PUT /contacts/4
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute]int id, [FromBody] UserDTO userDTO)
        {
            var userFromDb = await _repository.Get(id);

            if (userFromDb == null)
                return NotFound("There is no User with this Id.");

            userDTO.Id = id; // nécessaire dans le cas où l'id n'est pas ou mal définit dan la requete

            var user = _mapper.Map<User>(userDTO)!;

            var userUpdated = await _repository.Update(user);

            var userUpdatedDTO = _mapper.Map<UserDTO>(userUpdated);

            if (userUpdated != null)
                return Ok(new
                {
                    Message = "User Updated.",
                    Contact = userUpdatedDTO
                });

            return BadRequest("Something went wrong...");
        }


        //DELETE /contacts/12
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _repository.Delete(id))
                return Ok("User Deleted");

            //return NotFound("Contact Not Found");
            return BadRequest("Something went wrong...");
        }


        ////GET /contacts
        //[HttpGet("fullnames")]
        //public async Task<IActionResult> GetAllFullNames()
        //{
        //    IEnumerable<Contact> contacts = await _repository.GetAll();

        //    IEnumerable<ContactDTO> contactDTOs = _mapper.Map<IEnumerable<ContactDTO>>(contacts)!;

        //    IEnumerable<ContactFullNameDTO> fullnames = _mapper.Map<IEnumerable<ContactFullNameDTO>>(contactDTOs)!;

        //    return Ok(fullnames);
        //}
    }
}
