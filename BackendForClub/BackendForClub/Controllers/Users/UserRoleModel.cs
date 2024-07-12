using BackendForClub.DataModels;
using System.ComponentModel.DataAnnotations;

namespace BackendForClub.Controllers.Users
{
    public class UserRoleModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public UserRole Role { get; set; }
    }
}
