using BackendForClub.DataModels;
using System.ComponentModel.DataAnnotations;

namespace BackendForClub.Controllers.Registration
{
    public class RegModel
    {
        [Required]
        [MaxLength(50)]
        public string Login { get; set; } = null!;
        [Required]
        [MaxLength(100)]
        public string Password { get; set; } = null!;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        public UserRole Role = UserRole.Client;
        public UserStatus Status = UserStatus.White;
        public string DateRegistration { get; } = DateTime.Now.ToString();
        public int Balance { get; } = 0;
    }
}
