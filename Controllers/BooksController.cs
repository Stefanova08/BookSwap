using BookSwap.Models;
using BookSwap.Services;
using BookSwap.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookSwap.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<IActionResult> Index()
        {
            var books = await _bookService.GetAllAsync();
            return View(books);
        }

        public async Task<IActionResult> Details(int id)
        {
            var book = await _bookService.GetByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new BookFormViewModel();
            await LoadDropdownsAsync(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                await LoadDropdownsAsync(model);
                return View(model);
            }

            var book = new Book
            {
                Title = model.Title,
                Author = model.Author,
                Price = model.Price,
                Condition = model.Condition,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                CategoryId = model.CategoryId,
                CityId = model.CityId
            };

            await _bookService.AddAsync(book);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var book = await _bookService.GetByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            var model = new BookFormViewModel
            {
                Title = book.Title,
                Author = book.Author,
                Price = book.Price,
                Condition = book.Condition,
                Description = book.Description,
                ImageUrl = book.ImageUrl,
                CategoryId = book.CategoryId,
                CityId = book.CityId
            };

            await LoadDropdownsAsync(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BookFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                await LoadDropdownsAsync(model);
                return View(model);
            }

            var book = await _bookService.GetByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            book.Title = model.Title;
            book.Author = model.Author;
            book.Price = model.Price;
            book.Condition = model.Condition;
            book.Description = model.Description;
            book.ImageUrl = model.ImageUrl;
            book.CategoryId = model.CategoryId;
            book.CityId = model.CityId;

            await _bookService.UpdateAsync(book);
            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _bookService.GetByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _bookService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task LoadDropdownsAsync(BookFormViewModel model)
        {
            model.Categories = await _bookService.GetCategoriesAsync();
            model.Cities = await _bookService.GetCitiesAsync();
        }
    }
}