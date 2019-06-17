using System.ComponentModel.DataAnnotations;

namespace DutchTreat.Models
{
    public class OrderItemDto
    {
        public int Id { get; set; }

        [Required]
        public int Quatity { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }
    }
}