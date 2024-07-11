using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BackendForClub.DataModels
{
    public class SessionModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }
        public UserModel User { get; set; } = null!;
        [Required]
        [ForeignKey("Computer")]
        public int ComputerId { get; set; }
        public ComputerModel Computer { get; set; } = null!;
        [Required]
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
