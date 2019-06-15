using System.ComponentModel.DataAnnotations;

namespace DutchTreat.Models
{
    public class ContactViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [MaxLength(1)]
        public string Subject { get; set; }

        [MaxLength(1)]
        public string Message { get; set; }
    }
}