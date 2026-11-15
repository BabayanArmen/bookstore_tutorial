using BookStore.Data;
using BookStore.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repositories.AuthorRepo
{
    public class AuthorRepo(AppDbContext _db) : IAuthorRepo
    {
        public async Task AddASync(Author author)
        {
            await _db.Authors.AddAsync(author);
            await _db.SaveChangesAsync();
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
