using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using ContactApiDTOAsync.Validator;

namespace ContactApiDTOAsync.Models
{
    [Table("user")]
    public class User
    {

        [Column("id")]
        public int Id { get; set; }
        [Column("firstname")]
        [Required]
        public string? FirstName { get; set; }
        [Column("lastname")]
        [Required]
        public string? LastName { get; set; }
        [Column("birth_date")]
        [Required]
        public DateTime BirthDate { get; set; }
        [Column("gender")]
        [Required]
        [StringLength(1)]
        public string? Gender { get; set; }

        [Required]
        public bool IsAdmin { get; set; } = false;

        [RegularExpression(@"^([a-zA-Z0-9\.\-_]+)@([a-zA-Z0-9\-_]+)(\.)?([a-zA-Z0-9\-_]+)?(\.){1}([a-zA-Z]{2,11})$", ErrorMessage = "Invalid email address")]
        [Required]
        public String Email { get; set; }

        [PasswordValidator]                  
        [Required]
        public String Password { get; set; }



    }
}
