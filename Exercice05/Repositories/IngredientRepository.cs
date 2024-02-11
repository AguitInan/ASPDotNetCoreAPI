﻿using Exercice05.Data;
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
    }
}
