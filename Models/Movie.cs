using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }

        [Required]
        public string Category { get; set; } = string.Empty;

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        [Range(1888, 3000)]
        public int Year { get; set; }

        [Required]
        public string Director { get; set; } = string.Empty;

        // Must be one of: G, PG, PG-13, R
        [Required]
        public string Rating { get; set; } = string.Empty;

        // Optional
        public bool? Edited { get; set; }

        // Optional
        public string? LentTo { get; set; }

        // Optional, max 25 chars
        [StringLength(25)]
        public string? Notes { get; set; }
    }
}
