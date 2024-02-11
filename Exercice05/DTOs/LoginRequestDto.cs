using Exercice05.Validator;
using System.ComponentModel.DataAnnotations;

namespace Exercice05.DTOs
{
    public class LoginRequestDto
    {
        [Required]
        public string? Email { get; set; }

        [Required]
        [PasswordValidator]
        public string Password { get; set; }


    }
}
