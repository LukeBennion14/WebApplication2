using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }

        // In the DB this is CategoryId (foreign key), not a text Category
        [Display(Name = "Category")]
        public int? CategoryId { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        [Range(1888, 3000)]
        public int Year { get; set; }

        public string? Director { get; set; }

        public string? Rating { get; set; }

        // DB stores this as INTEGER 0/1 and it is NOT NULL
        [Required]
        public bool Edited { get; set; }

        public string? LentTo { get; set; }

        // DB stores this as INTEGER 0/1 and it is NOT NULL
        [Required]
        public bool CopiedToPlex { get; set; }

        [StringLength(25)]
        public string? Notes { get; set; }
    }
}