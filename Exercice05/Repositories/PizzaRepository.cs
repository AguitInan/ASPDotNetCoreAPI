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

        public async Task<IEnumerable<Pizza>> GetAll()
        {
            return _db.Pizzas;
            // DbSet<> implémente l'interface IEnumerable
            // en ne faisant pas le .ToList() tout de suite, on repousse l'exécution de la requête LINQ
            // cela est plus otpimisé/pratique

            //return await _db.Contacts.ToListAsync();
        }

        public async Task<IEnumerable<Pizza>> GetAll(Expression<Func<Pizza, bool>> predicate)
        {
            return _db.Pizzas.Where(predicate);
            //return await _db.Contacts.Where(predicate).ToListAsync();
        }


        // UPDATE
        public async Task<Pizza?> Update(Pizza pizza)
        {
            var pizzaFromDb = await Get(pizza.Id); // entitée récupérée donc TRAQUEE par l'ORM (EFCore)

            if (pizzaFromDb == null)
                return null; // erreur lors de la modification => contact non trouvé

            if (pizzaFromDb.Name != pizza.Name)
                pizzaFromDb.Name = pizza.Name;
            if (pizzaFromDb.Description != pizza.Description)
                pizzaFromDb.Description = pizza.Description;
            if (pizzaFromDb.Price != pizza.Price)
                pizzaFromDb.Price = pizza.Price;
            if (pizzaFromDb.ImageUrl != pizza.ImageUrl)
                pizzaFromDb.ImageUrl = pizza.ImageUrl;
            if (pizzaFromDb.Variety != pizza.Variety)
                pizzaFromDb.Variety = pizza.Variety;

            if (await _db.SaveChangesAsync() == 0)
                return null; // erreur lors de la modification

            return pizzaFromDb;
        }


        // DELETE
        public async Task<bool> Delete(int id)
        {
            var pizzaFromDb = await Get(id); // entitée récupérée donc TRAQUEE par l'ORM (EFCore)

            if (pizzaFromDb == null)
                return false; // erreur lors de la suppression => contact non trouvé

            _db.Pizzas.Remove(pizzaFromDb);

            return await _db.SaveChangesAsync() > 0;
        }
    }
}
