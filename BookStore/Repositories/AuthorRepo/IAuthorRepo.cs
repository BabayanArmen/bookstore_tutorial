using BookStore.Entities;

namespace BookStore.Repositories.AuthorRepo
{
    public interface IAuthorRepo
    {
        Task<List<Author>> GetAllAsync();
        Task<Author?> GetByIdAsync(int id);
        Task<Author> AddAsync(Author author);
        Task<bool> UpdateAsync(Author author);
        Task<bool> DeleteAsync(int id);
    }
}
