using Exercice05.Data;
using Exercice05.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Exercice05.Repositories
{
    public class IngredientRepository : IRepository<Ingredient>
    {
        private readonly AppDbContext _db;

        public IngredientRepository(AppDbContext db)
        {
            _db = db;
        }

        // CREATE
        public async Task<Ingredient?> Add(Ingredient ingredient)
        {
            var addEntry = await _db.Ingredients.AddAsync(ingredient); // retourne un EntityEntry<Contact> qui enveloppe le nouveau contact créé
            await _db.SaveChangesAsync();

            if (addEntry.Entity.Id > 0) // si l'entité est bien ajoutée l'id est > 0
                return addEntry.Entity;

            return null; // erreur lors de l'ajout
        }


        // READ
        public async Task<Ingredient?> Get(int id)
        {
            //return _db.Contacts.Find(id); // ne fonctionne que sur un DbSet<> (EFCore)
            return await _db.Ingredients.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Ingredient?> Get(Expression<Func<Ingredient, bool>> predicate)
        {
            return await _db.Ingredients.FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<Ingredient>> GetAll()
        {
            return _db.Ingredients;
            // DbSet<> implémente l'interface IEnumerable
            // en ne faisant pas le .ToList() tout de suite, on repousse l'exécution de la requête LINQ
            // cela est plus otpimisé/pratique

            //return await _db.Contacts.ToListAsync();
        }

        public async Task<IEnumerable<Ingredient>> GetAll(Expression<Func<Ingredient, bool>> predicate)
        {
            return _db.Ingredients.Where(predicate);
            //return await _db.Contacts.Where(predicate).ToListAsync();
        }


        // UPDATE
        public async Task<Ingredient?> Update(Ingredient ingredient)
        {
            var ingredientFromDb = await Get(ingredient.Id); // entitée récupérée donc TRAQUEE par l'ORM (EFCore)

            if (ingredientFromDb == null)
                return null; // erreur lors de la modification => contact non trouvé

            if (ingredientFromDb.Name != ingredient.Name)
                ingredientFromDb.Name = ingredient.Name;
            if (ingredientFromDb.Description != ingredient.Description)
                ingredientFromDb.Description = ingredient.Description;

            if (await _db.SaveChangesAsync() == 0)
                return null; // erreur lors de la modification

            return ingredientFromDb;
        }


        // DELETE
        public async Task<bool> Delete(int id)
        {
            var ingredientFromDb = await Get(id); // entitée récupérée donc TRAQUEE par l'ORM (EFCore)

            if (ingredientFromDb == null)
                return false; // erreur lors de la suppression => contact non trouvé

            _db.Ingredients.Remove(ingredientFromDb);

            return await _db.SaveChangesAsync() > 0;
        }
    }
}
