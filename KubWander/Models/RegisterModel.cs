using System.ComponentModel.DataAnnotations;

namespace KubWander.Models
{
    public class RegisterModel
    {
        [Required]
        public string Name {  get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
