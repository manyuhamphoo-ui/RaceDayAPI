using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RaceDayAPI.Models
{
    public class EventEnrollment
    {
        [Key]
        public int EnrollmentId { get; set; }

        [ForeignKey("Participant")]
        public int ParticipantId { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public DateTime RegistrationDate { get; set; }

        [Required]
        public string Status { get; set; } = string.Empty;

        [Required]
        public string RaceNumber { get; set; } = string.Empty;

        // Navigation Properties
        public Participant? Participant { get; set; }

        public Category? Category { get; set; }
    }
}