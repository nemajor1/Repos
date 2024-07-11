using System.ComponentModel.DataAnnotations;

namespace BackendForClub.Controllers.Authorization
{
    public class AuthModel
    {
        [Required]
        public string Login { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}
