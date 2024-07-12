using System.ComponentModel.DataAnnotations;

namespace BackendForClub.Controllers.Users
{
    public class UserEmailModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
    }
}
