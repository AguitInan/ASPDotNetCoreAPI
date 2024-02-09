using ContactApiDTO.Models;
using ContactApiDTOAsync.Helpers;
using ContactApiDTOAsync.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactApiDTO.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
#nullable disable
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var adminRoot = new User()
            {
                Id = 1,
                FirstName = "Root",
                LastName = "ROOT",
                BirthDate = new DateTime(2000, 1, 1),
                Gender = "X",
                IsAdmin = true,
                Email = "root@utopios.com",
                Password = PasswordCrypter.Encrypt("PAss00++", "Des paillettes dans mes yeux Kevin") 
                //Password = "UEFzczAwKytEZXMgcGFpbGxldHRlcyBkYW5zIG1lcyB5ZXV4IEtldmlu"

            };
            modelBuilder.Entity<User>().HasData(adminRoot);
        }
    }
}
