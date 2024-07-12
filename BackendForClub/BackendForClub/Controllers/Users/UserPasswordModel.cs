using System.ComponentModel.DataAnnotations;

namespace BackendForClub.Controllers.Users
{
    public class UserPasswordModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Password { get; set; } = null!;
    }
}
