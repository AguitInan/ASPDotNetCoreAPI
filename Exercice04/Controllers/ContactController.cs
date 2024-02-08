using Microsoft.AspNetCore.Mvc;
using Exercice04.Models;
using System.Linq.Expressions;
using System;

namespace Exercice04.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly IRepository<Contact> _contactRepository;

        public ContactsController(IRepository<Contact> contactRepository)
        {
            _contactRepository = contactRepository;
        }
    }
}
