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

    }
}
