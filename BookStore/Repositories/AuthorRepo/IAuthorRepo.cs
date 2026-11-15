using BookStore.Entities;

namespace BookStore.Repositories.AuthorRepo
{
    public interface IAuthorRepo
    {
        Task<List<Author>> GetAllAsync();
        Task<Author?> GetByIdAsync(int id);
        Task AddASync(Author author);
        Task UpdateAsync (Author author);
        Task DeleteAsync(int id);
    }
}
