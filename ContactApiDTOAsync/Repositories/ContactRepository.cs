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
    }
}
