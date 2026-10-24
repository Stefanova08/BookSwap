using BookSwap.Models;

namespace BookSwap.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book?> GetByIdAsync(int id);
        Task AddAsync(Book book);
        Task UpdateAsync(Book book);
        Task DeleteAsync(int id);

        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<IEnumerable<City>> GetCitiesAsync();
    }
}