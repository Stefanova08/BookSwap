using BookSwap.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookSwap.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllWithBookCountAsync();
            return View(categories);
        }

        public async Task<IActionResult> Details(int id)
        {
            var category = await _categoryService.GetByIdWithBooksAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
    }
}