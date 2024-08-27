using System.ComponentModel.DataAnnotations;

namespace Dotnet8.Model
{
    public class OurHero
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public string Role { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public bool isActive { get; set; } = true;
    }
}
