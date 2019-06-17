using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DutchTreat.Models
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        
        [Required]
        [MinLength(4)]
        public string OrderNumber { get; set; }
    }   
}