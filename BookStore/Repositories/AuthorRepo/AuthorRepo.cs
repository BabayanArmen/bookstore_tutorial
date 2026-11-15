using BookStore.Data;
using BookStore.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repositories.AuthorRepo
{
    public class AuthorRepo(AppDbContext _db) : IAuthorRepo
    {
        public Task AddASync(Author author)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Author>> GetAllAsync()
        {
            return await _db.Authors
                .ToListAsync();
        }

        public async Task<Author?> GetByIdAsync(int id)
        {
            return await _db.Authors
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task UpdateAsync(Author author)
        {
            throw new NotImplementedException();
        }
    }
}
