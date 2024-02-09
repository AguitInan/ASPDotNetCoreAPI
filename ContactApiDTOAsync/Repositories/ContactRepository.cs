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
    }
}
