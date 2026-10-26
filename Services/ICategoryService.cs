using BookSwap.Models;
using BookSwap.ViewModels;

namespace BookSwap.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryViewModel>> GetAllWithBookCountAsync();
        Task<Category?> GetByIdWithBooksAsync(int id);
    }
}