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
    }
}
