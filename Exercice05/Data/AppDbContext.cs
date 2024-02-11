using Exercice05.Models;
using Exercice05.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using static Exercice05.Models.Pizza;

namespace Exercice05.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
#nullable disable
        public DbSet<User> Users { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var adminRoot = new User()
            {
                Id = 1,
                FirstName = "Root",
                LastName = "ROOT",
                IsAdmin = true,
                Email = "root@utopios.com",
                Password = PasswordCrypter.Encrypt("PAss00++", "Des paillettes dans mes yeux Kevin")
                //Password = "UEFzczAwKytEZXMgcGFpbGxldHRlcyBkYW5zIG1lcyB5ZXV4IEtldmlu"

            };
            modelBuilder.Entity<User>().HasData(adminRoot);

            modelBuilder.Entity<Ingredient>().HasData(

            new Ingredient
            {
                Id = 1,
                Name = "Tomate",
                Description = "Tomate d'Espagne",
            },

            new Ingredient
            {
                Id = 2,
                Name = "Poulet",
                Description = "Poulet grillé",
            },

            new Ingredient
            {
                Id = 3,
                Name = "Viande",
                Description = "Viande de boeuf",
            });

            modelBuilder.Entity<Pizza>().HasData(

            new Pizza {
                Id = 1,
                Name = "Margherita",
                Description = "Classic pizza with tomato sauce, mozzarella, and fresh basil.",
                Price = 8.99m,
                ImageUrl = "https://example.com/images/margherita.jpg",
                Variety = PizzaType.Vegetarienne},

            new Pizza
            {
                Id = 2,
                Name = "Pepperoni",
                Description = "Spicy pepperoni with mozzarella cheese and tomato sauce.",
                Price = 10.99m,
                ImageUrl = "https://example.com/images/pepperoni.jpg",
                Variety = PizzaType.Vegetarienne
            },

            new Pizza {
                Id = 3,
                Name = "Vegetarian",
                Description = "A delightful mix of seasonal vegetables, mozzarella, and tomato sauce.",
                Price = 9.99m,
                ImageUrl = "https://example.com/images/vegetarian.jpg",
                Variety = PizzaType.Vegetarienne},

            new Pizza {
                Id = 4,
                Name = "Hawaiian",
                Description = "Ham and pineapple with mozzarella cheese and tomato sauce.",
                Price = 11.99m,
                ImageUrl = "https://example.com/images/hawaiian.jpg",
                Variety = PizzaType.Piquante},

            new Pizza {
                Id = 5,
                Name = "Spicy",
                Description = "Hot jalapenos, spicy pepperoni, mozzarella, and tomato sauce.",
                Price = 12.99m,
                ImageUrl = "https://example.com/images/spicy.jpg",
                Variety = PizzaType.Piquante});
        }
    }
}
