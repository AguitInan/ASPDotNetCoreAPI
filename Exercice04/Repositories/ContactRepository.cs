using Exercice04.Data;
using System.Linq.Expressions;
using Exercice04.Data;
using Exercice04.Models;

namespace Exercice04.Repositories
{
    public class ContactRepository : IRepository<Contact>
    {
        private readonly ApplicationDbContext _dbContext;
        public ContactRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        // CREATE
        public bool Add(Contact contact)
        {
            var addedObj = _dbContext.Contacts.Add(contact);
            _dbContext.SaveChanges();
            return addedObj.Entity.Id > 0;
        }
    }
}
