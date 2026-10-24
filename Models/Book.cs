using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookSwap.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, MinimumLength = 2)]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = "Author is required.")]
        [StringLength(80, MinimumLength = 2)]
        public string Author { get; set; } = null!;

        [Range(0.01, 1000, ErrorMessage = "Price must be between 0.01 and 1000.")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        [Required]
        public BookCondition Condition { get; set; }

        [StringLength(1000)]
        public string? Description { get; set; }

        [Url(ErrorMessage = "Please enter a valid URL.")]
        public string? ImageUrl { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        [Display(Name = "City")]
        public int CityId { get; set; }
        public City City { get; set; } = null!;
    }
}