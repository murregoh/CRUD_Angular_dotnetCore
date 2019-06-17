using System.ComponentModel.DataAnnotations;

namespace DutchTreat.Data.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int Quatity { get; set; }
        public decimal UnitPrice { get; set; }
        public Order Order { get; set; }
    }
}