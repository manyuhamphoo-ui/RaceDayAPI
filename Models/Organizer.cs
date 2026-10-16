using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RaceDayAPI.Models
{
    public class Organizer
    {
        [Key]
        public int OrganizerId { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Organization Name is required.")]
        [StringLength(100, ErrorMessage = "Organization Name cannot exceed 100 characters.")]
        public string OrganizationName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Contact Number is required.")]
        [Phone(ErrorMessage = "Please enter a valid phone number.")]
        [StringLength(20)]
        public string ContactNumber { get; set; } = string.Empty;

        // Navigation Property
        public User? User { get; set; }
    }
}