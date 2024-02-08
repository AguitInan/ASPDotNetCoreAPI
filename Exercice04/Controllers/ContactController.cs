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

        // GET: api/contacts
        [HttpGet]
        public IActionResult GetAll()
        {
            var contacts = _contactRepository.GetAll();
            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //var contact = _fakeDb.Contacts.FirstOrDefault(c => c.Id == id);
            var contact = _contactRepository.GetById(id);

            if (contact == null)
                return NotFound(new
                {
                    Message = "Contact non trouvée !"
                });

            return Ok(new
            {
                Message = "Contact trouvée !",
                Contact = contact
            });
        }
    }
}
