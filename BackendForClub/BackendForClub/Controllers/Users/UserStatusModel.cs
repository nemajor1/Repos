using BackendForClub.DataModels;
using System.ComponentModel.DataAnnotations;

namespace BackendForClub.Controllers.Users
{
    public class UserStatusModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public UserStatus Status { get; set; }
    }
}
