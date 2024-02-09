using ContactApiDTO.Data;
using ContactApiDTO.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ContactApiDTO.Repositories
{
    public class ContactRepository : IRepository<Contact>
    {
        private readonly AppDbContext _db;

        public ContactRepository(AppDbContext db)
        {
            _db = db;
        }

        // CREATE
        public async Task<Contact?> Add(Contact contact)
        {
            var addEntry = await _db.Contacts.AddAsync(contact); // retourne un EntityEntry<Contact> qui enveloppe le nouveau contact créé
            await _db.SaveChangesAsync();

            if (addEntry.Entity.Id > 0) // si l'entité est bien ajoutée l'id est > 0
                    return addEntry.Entity;

            return null; // erreur lors de l'ajout
        }


        // READ
        public async Task<Contact?> Get(int id)
        {
            //return _db.Contacts.Find(id); // ne fonctionne que sur un DbSet<> (EFCore)
            return await _db.Contacts.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Contact?> Get(Expression<Func<Contact, bool>> predicate)
        {
            return await _db.Contacts.FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<Contact>> GetAll()
        {
            return _db.Contacts; 
            // DbSet<> implémente l'interface IEnumerable
            // en ne faisant pas le .ToList() tout de suite, on repousse l'exécution de la requête LINQ
            // cela est plus otpimisé/pratique

            //return await _db.Contacts.ToListAsync();
        }

        public async Task<IEnumerable<Contact>> GetAll(Expression<Func<Contact, bool>> predicate)
        {
            return _db.Contacts.Where(predicate);
            //return await _db.Contacts.Where(predicate).ToListAsync();
        }


        // UPDATE
        public async Task<Contact?> Update(Contact contact)
        {
            var contactFromDb = await Get(contact.Id); // entitée récupérée donc TRAQUEE par l'ORM (EFCore)

            if (contactFromDb == null)
                return null; // erreur lors de la modification => contact non trouvé

            if (contactFromDb.FirstName != contact.FirstName)
                contactFromDb.FirstName = contact.FirstName;
            if (contactFromDb.LastName != contact.LastName)
                contactFromDb.LastName = contact.LastName;
            if (contactFromDb.BirthDate != contact.BirthDate)
                contactFromDb.BirthDate = contact.BirthDate;
            if (contactFromDb.Gender != contact.Gender)
                contactFromDb.Gender = contact.Gender;

            if (await _db.SaveChangesAsync() == 0)
                return null; // erreur lors de la modification

            return contactFromDb;
        }


        // DELETE
        public async Task<bool> Delete(int id)
        {
            var contactFromDb = await Get(id); // entitée récupérée donc TRAQUEE par l'ORM (EFCore)

            if (contactFromDb == null)
                return false; // erreur lors de la suppression => contact non trouvé

            _db.Contacts.Remove(contactFromDb);

            return await _db.SaveChangesAsync() > 0;
        }
    }
}
