using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using Exercice04.Models;

namespace Exercice04.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\demo01ado;Database=contact;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().HasData(
            new Contact { Id = 1, FirstName = "Iori", LastName = "Yagami", Password = "pwd1", AvatarURL = "URL1", Phone = "0123456789", Email = "testc@mail.com", BirthDate = new DateTime(1987, 1, 1) },
            new Contact { Id = 2, FirstName = "Kyo", LastName = "Kusanagi", Password = "pwd2", AvatarURL = "URL2", Phone = "0123456789", Email = "testc@mail.com", BirthDate = new DateTime(1990, 1, 1) },
            new Contact { Id = 3, FirstName = "Kazuya", LastName = "Mishima", Password = "pwd3", AvatarURL = "URL3", Phone = "0123456789", Email = "testc@mail.com", BirthDate = new DateTime(1995, 1, 1) });
        }
    }
}
