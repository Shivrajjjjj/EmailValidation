using System.ComponentModel.DataAnnotations;

namespace EmailValidation.EmailValidation.Models
{
    public class EmailRequest
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Enter a valid email address")]
        public string Email { get; set; }
    }
}
