using BookSwap.Data;
using BookSwap.Models;
using BookSwap.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BookSwap.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CategoryViewModel>> GetAllWithBookCountAsync()
        {
            return await _context.Categories
                .OrderBy(c => c.Name)
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    BookCount = c.Books.Count
                })
                .ToListAsync();
        }

        public async Task<Category?> GetByIdWithBooksAsync(int id)
        {
            return await _context.Categories
                .Include(c => c.Books)
                    .ThenInclude(b => b.City)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}