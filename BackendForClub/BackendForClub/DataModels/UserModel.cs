using System.ComponentModel.DataAnnotations;

namespace BackendForClub.DataModels
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Login { get; set; } = null!;
        [Required]
        [MaxLength(100)]
        public string Password { get; set; } = null!;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        public UserRole Role { get; set; }
        [Required]
        public UserStatus Status { get; set; }
        [Required]
        public string DateRegistration { get; set; } = null!;
        [Required]
        public int Balance { get; set; } = 0;
    }
    public enum UserRole
    {
        Admin,
        Client,
        Director
    }
    public enum UserStatus
    {
        Black,
        White
    }
}
