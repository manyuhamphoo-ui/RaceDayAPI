using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RaceDayAPI.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }

        [Required]
        [ForeignKey("Organizer")]
        public int OrganizerId { get; set; }

        [Required(ErrorMessage = "Event Name is required.")]
        [StringLength(100, ErrorMessage = "Event Name cannot exceed 100 characters.")]
        public string EventName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Event Type is required.")]
        [StringLength(50)]
        public string EventType { get; set; } = string.Empty;

        [Required(ErrorMessage = "Event Date is required.")]
        [DataType(DataType.DateTime)]
        public DateTime EventDate { get; set; }

        [Required(ErrorMessage = "Location is required.")]
        [StringLength(150)]
        public string Location { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(500)]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Status is required.")]
        [StringLength(20)]
        public string Status { get; set; } = string.Empty;

        // Navigation Property
        public Organizer? Organizer { get; set; }
    }
}