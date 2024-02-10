using ContactApiDTOAsync.Validator;
using System.ComponentModel.DataAnnotations;

namespace ContactApiDTOAsync.DTOs
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
