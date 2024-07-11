using System.ComponentModel.DataAnnotations;

namespace BackendForClub.DataModels
{
    public class BarModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int Price { get; set; }
    }
}
