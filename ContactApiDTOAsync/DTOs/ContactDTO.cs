using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ContactApiDTO.DTOs
{
    public class ContactDTO
    {
        // le Data Transfert Object sert à transférer de la donnée
        // il peut être une version modifiée d'un model ou une nouvelle classe 
        // il est dédié à l'interraction avec l'API
        // on y retrouve des data annotations liée à la validation par exemple
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"^[A-Z][A-Za-z\- ]*", ErrorMessage = "FirstName must start with an uppercase letter !")]
        public string? FirstName { get; set; }
        [Required]
        [RegularExpression(@"^[A-Z\- ]*", ErrorMessage = "LastName must be in uppercase !")]
        public string? LastName { get; set; }
        public string? FullName => FirstName + " " + LastName; // get => pas d'attribut/variable FullName
        [Required]
        //[JsonIgnore] // la prop sera ignorée pour la serialisation de l'objet
        public DateTime BirthDate { get; set; }
        public int Age
        {
            get // get => pas d'attribut/variable age
            {
                int age = DateTime.Now.Year - BirthDate.Year;
                if (BirthDate > DateTime.Now.AddYears(-age)) //ajout de vérification mois/jour
                    age--;
                return age;
            }
        }
        [Required]
        [RegularExpression(@"[FMN]", ErrorMessage = "Gender must be either F, M, or N.")]
        [StringLength(1)]
        public string? Gender { get; set; }
    }
}
