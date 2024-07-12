using System.ComponentModel.DataAnnotations;

namespace BackendForClub.Controllers.Users
{
    public class UserLoginModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Login { get; set; } = null!;
    }
}
