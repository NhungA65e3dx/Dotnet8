using System.ComponentModel.DataAnnotations;

namespace Dotnet8.Model
{
    public class AddUpdateCustomer
    {
        public int Id { get; set; }
        
        public string UserName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; } = string.Empty;
        public string Role { get; set; }
        public bool isActive { get; set; } = true;
    }
}
