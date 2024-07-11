using System.ComponentModel.DataAnnotations;

namespace BackendForClub.DataModels
{
    public class ComputerModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string IpAdress { get; set; } = null!;
        [Required]
        public string MacAdress { get; set; } = null!;
        [Required]
        public Status Status { get; set; }
    }
    public enum Status
    {
        On,
        Off,
        Unlocked,
        Maintenance
    }
}
