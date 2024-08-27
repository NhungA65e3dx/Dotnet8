

using System.ComponentModel.DataAnnotations;

namespace Dotnet8.Model
{
    public class User
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public string LastName { get; set; }
        public required string Username { get; set; }
        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }      
        [Required]
        public string Role { get; set; }
        public bool isActive { get; set; }
    }
}
