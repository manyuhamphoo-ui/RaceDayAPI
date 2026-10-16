using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RaceDayAPI.Models
{
    public class Result
    {
        [Key]
        public int ResultId { get; set; }

        [ForeignKey("EventEnrollment")]
        public int EnrollmentId { get; set; }

        public TimeSpan FinishTime { get; set; }

        public int Position { get; set; }

        [Required]
        public string ResultStatus { get; set; } = string.Empty;

        // Navigation Property
        public EventEnrollment? EventEnrollment { get; set; }
    }
}