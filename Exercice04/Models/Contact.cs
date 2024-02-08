using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Exercice04.Models
{
    [Table("contact")]
    public class Contact
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("firstname")]
        [Display(Name = "Prénom du contact")]
        public string FirstName { get; set; }

        [Column("lastname")]
        [Display(Name = "Nom du contact")]
        public string LastName { get; set; }
        [NotMapped]
        [Display(Name = "Nom complet du contact")]
        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }

        [Column("password")]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }

        [Column("avatarURL")]
        [Display(Name = "Avatar du contact")]
        public string AvatarURL { get; set; }

        [Column("phone")]
        [Display(Name = "Numéro de téléphone")]
        public string Phone { get; set; }

        [Column("email")]
        [Display(Name = "Email du contact")]
        public string Email { get; set; }

        [Column("birthdate")]
        [Display(Name = "Date de naissance")]
        public DateTime BirthDate { get; set; }

        [NotMapped]
        [Display(Name = "Âge du contact")]
        public int Age
        {
            get
            {
                DateTime now = DateTime.Today;
                int age = now.Year - BirthDate.Year;
                if (BirthDate.Date > now.AddYears(-age)) age--;
                return age;
            }
        }
    }
}
