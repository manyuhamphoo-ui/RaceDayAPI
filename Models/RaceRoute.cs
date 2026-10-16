using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RaceDayAPI.Models
{
    public class RaceRoute
    {
        [Key]
        public int RouteId { get; set; }

        [ForeignKey("Event")]
        public int EventId { get; set; }

        [Required]
        public string RouteName { get; set; } = string.Empty;

        public double DistanceKm { get; set; }

        [Required]
        public string StartPoint { get; set; } = string.Empty;

        [Required]
        public string EndPoint { get; set; } = string.Empty;

        [Required]
        public string MapUrl { get; set; } = string.Empty;

        // Navigation Property
        public Event? Event { get; set; }
    }
}