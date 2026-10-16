using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RaceDayAPI.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [ForeignKey("Event")]
        public int EventId { get; set; }

        [Required(ErrorMessage = "Category Name is required.")]
        [StringLength(100, ErrorMessage = "Category Name cannot exceed 100 characters.")]
        public string CategoryName { get; set; } = string.Empty;

        [Required]
        [Range(0.1, 1000, ErrorMessage = "Distance must be greater than 0 km.")]
        public double DistanceKm { get; set; }

        [Required]
        [Range(1, 100000, ErrorMessage = "Maximum participants must be at least 1.")]
        public int MaxParticipants { get; set; }

        [Required]
        [Range(typeof(decimal), "0", "100000", ErrorMessage = "Entry Fee cannot be negative.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal EntryFee { get; set; }

        // Navigation Property
        public Event? Event { get; set; }
    }
}