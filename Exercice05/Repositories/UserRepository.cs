using Exercice05.Data;
using Exercice05.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Exercice05.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly AppDbContext _db;

        public UserRepository(AppDbContext db)
        {
            _db = db;
        }

        // CREATE
        public async Task<User?> Add(User user)
        {
            var addEntry = await _db.Users.AddAsync(user); // retourne un EntityEntry<Contact> qui enveloppe le nouveau contact créé
            await _db.SaveChangesAsync();

            if (addEntry.Entity.Id > 0) // si l'entité est bien ajoutée l'id est > 0
                return addEntry.Entity;

            return null; // erreur lors de l'ajout
        }


        // READ
        public async Task<User?> Get(int id)
        {
            //return _db.Contacts.Find(id); // ne fonctionne que sur un DbSet<> (EFCore)
            return await _db.Users.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<User?> Get(Expression<Func<User, bool>> predicate)
        {
            return await _db.Users.FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return _db.Users;
            // DbSet<> implémente l'interface IEnumerable
            // en ne faisant pas le .ToList() tout de suite, on repousse l'exécution de la requête LINQ
            // cela est plus otpimisé/pratique

            //return await _db.Contacts.ToListAsync();
        }

        public async Task<IEnumerable<User>> GetAll(Expression<Func<User, bool>> predicate)
        {
            return _db.Users.Where(predicate);
            //return await _db.Contacts.Where(predicate).ToListAsync();
        }


        // UPDATE
        public async Task<User?> Update(User user)
        {
            var userFromDb = await Get(user.Id); // entitée récupérée donc TRAQUEE par l'ORM (EFCore)

            if (userFromDb == null)
                return null; // erreur lors de la modification => contact non trouvé

            if (userFromDb.FirstName != user.FirstName)
                userFromDb.FirstName = user.FirstName;
            if (userFromDb.LastName != user.LastName)
                userFromDb.LastName = user.LastName;
            if (userFromDb.IsAdmin != user.IsAdmin)
                userFromDb.IsAdmin = user.IsAdmin;
            if (userFromDb.Email != user.Email)
                userFromDb.Email = user.Email;
            if (userFromDb.Password != user.Password)
                userFromDb.Password = user.Password;

            if (await _db.SaveChangesAsync() == 0)
                return null; // erreur lors de la modification

            return userFromDb;
        }
    }
}
