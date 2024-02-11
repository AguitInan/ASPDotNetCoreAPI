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
    }
}
