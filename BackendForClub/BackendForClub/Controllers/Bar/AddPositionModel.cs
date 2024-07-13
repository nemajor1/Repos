using System.ComponentModel.DataAnnotations;

namespace BackendForClub.Controllers.Bar
{
    public class AddPositionModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;
    }
}
