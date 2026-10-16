using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RaceDayAPI.Models
{
    public class WeatherInformation
    {
        [Key]
        public int WeatherId { get; set; }

        [ForeignKey("Event")]
        public int EventId { get; set; }

        public DateTime ForecastDate { get; set; }

        public double Temperature { get; set; }

        public int RainProbability { get; set; }

        public double WindSpeed { get; set; }

        [Required]
        public string Conditions { get; set; } = string.Empty;

        // Navigation Property
        public Event? Event { get; set; }
    }
}