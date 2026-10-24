using System.ComponentModel.DataAnnotations;
using BookSwap.Models;

namespace BookSwap.ViewModels
{
    public class BookFormViewModel
    {
        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, MinimumLength = 2)]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = "Author is required.")]
        [StringLength(80, MinimumLength = 2)]
        public string Author { get; set; } = null!;

        [Range(0.01, 1000, ErrorMessage = "Price must be between 0.01 and 1000.")]
        public decimal Price { get; set; }

        [Required]
        public BookCondition Condition { get; set; }

        [StringLength(1000)]
        public string? Description { get; set; }

        [Url(ErrorMessage = "Please enter a valid URL.")]
        [Display(Name = "Image URL")]
        public string? ImageUrl { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please select a category.")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please select a city.")]
        [Display(Name = "City")]
        public int CityId { get; set; }

        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
        public IEnumerable<City> Cities { get; set; } = new List<City>();
    }
}