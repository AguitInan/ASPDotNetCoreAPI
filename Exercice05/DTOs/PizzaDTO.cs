using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Exercice05.Models;

namespace Exercice05.DTOs
{
    public class PizzaDTO
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        [Required]
        public string Name { get; set; }
        [Column("description")]
        [Required]
        public string Description { get; set; }
        [Column("price")]
        [Required]
        public decimal Price { get; set; }
        [Column("image_url")]
        [Required]
        public string ImageUrl { get; set; }
        [Column("pizza_type")]
        [Required]
        public PizzaType Variety { get; set; }
        public List<Ingredient> Ingredients { get; set; }

        public enum PizzaType
        {
            Vegetarienne,
            Piquante
        }
    }
}
