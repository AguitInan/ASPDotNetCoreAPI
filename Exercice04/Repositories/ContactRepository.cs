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

        // READ
        public Contact? GetById(int id)
        {
            return _dbContext.Contacts.Find(id);
        }
        public Contact? Get(Expression<Func<Contact, bool>> predicate)
        {
            return _dbContext.Contacts.FirstOrDefault(predicate);
        }
        public List<Contact> GetAll()
        {
            return _dbContext.Contacts.ToList();
        }
        public List<Contact> GetAll(Expression<Func<Contact, bool>> predicate)
        {
            return _dbContext.Contacts.Where(predicate).ToList();
        }

        // UPDATE
        public bool Update(Contact contact)
        {
            var contactFromDb = GetById(contact.Id);

            if (contactFromDb == null)
                return false;

            if (contactFromDb.FirstName != contact.FirstName)
                contactFromDb.FirstName = contact.FirstName;
            if (contactFromDb.LastName != contact.LastName)
                contactFromDb.LastName = contact.LastName;
            if (contactFromDb.Password != contact.Password)
                contactFromDb.Password = contact.Password;
            if (contactFromDb.AvatarURL != contact.AvatarURL)
                contactFromDb.AvatarURL = contact.AvatarURL;
            if (contactFromDb.Phone != contact.Phone)
                contactFromDb.Phone = contact.Phone;
            if (contactFromDb.Email != contact.Email)
                contactFromDb.Email = contact.Email;
            if (contactFromDb.BirthDate != contact.BirthDate)
                contactFromDb.BirthDate = contact.BirthDate;

            return _dbContext.SaveChanges() > 0;
        }
    }
}
