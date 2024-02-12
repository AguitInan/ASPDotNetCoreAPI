using AutoMapper;
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
    }
}
