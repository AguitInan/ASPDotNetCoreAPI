using AutoMapper;
using ContactApiDTO.DTOs;
using ContactApiDTO.Models;
using ContactApiDTO.Repositories;
using ContactApiDTOAsync.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ContactApiDTO.Controllers
{

    [Route("contacts")]
    [ApiController]
    [Authorize]
    public class ContactController : ControllerBase
    {
        private readonly IRepository<Contact> _repository;
        private readonly IMapper _mapper;

        public ContactController(IRepository<Contact> repository,
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
            IEnumerable<Contact> contacts = await _repository.GetAll();

            IEnumerable<ContactDTO> contactDTOs = _mapper.Map<IEnumerable<ContactDTO>>(contacts)!;
            //IEnumerable<ContactDTO> contactDTOs = _mapper.Map<IEnumerable<Contact>, IEnumerable<ContactDTO>>(contacts)!;

            // possible d'ajouter des modification par rapport aux DTOs ici

            return Ok(contactDTOs);
        }
    }
}
