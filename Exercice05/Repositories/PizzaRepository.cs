using Exercice05.Data;
using Exercice05.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Exercice05.Repositories
{
    public class PizzaRepository : IRepository<Pizza>
    {
        private readonly AppDbContext _db;

        public PizzaRepository(AppDbContext db)
        {
            _db = db;
        }

        // CREATE
        public async Task<Pizza?> Add(Pizza pizza)
        {
            var addEntry = await _db.Pizzas.AddAsync(pizza); // retourne un EntityEntry<Contact> qui enveloppe le nouveau contact créé
            await _db.SaveChangesAsync();

            if (addEntry.Entity.Id > 0) // si l'entité est bien ajoutée l'id est > 0
                return addEntry.Entity;

            return null; // erreur lors de l'ajout
        }


        // READ
        public async Task<Pizza?> Get(int id)
        {
            //return _db.Contacts.Find(id); // ne fonctionne que sur un DbSet<> (EFCore)
            return await _db.Pizzas.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Pizza?> Get(Expression<Func<Pizza, bool>> predicate)
        {
            return await _db.Pizzas.FirstOrDefaultAsync(predicate);
        }
    }
}
