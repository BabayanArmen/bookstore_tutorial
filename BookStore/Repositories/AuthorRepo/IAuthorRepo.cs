using BookStore.Entities;
using BookStore.FIlters;
using BookStore.Models;

namespace BookStore.Repositories.AuthorRepo
{
    public interface IAuthorRepo
    {
        Task<PageResult<Author>> GetAllAsync(AuthorFilter filter);
        Task<Author?> GetByIdAsync(int id);
        Task<Author> AddAsync(Author author);
        Task<bool> UpdateAsync(Author author);
        Task<bool> DeleteAsync(int id);
    }
}
