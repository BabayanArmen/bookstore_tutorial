using BookStore.Data;
using BookStore.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repositories.AuthorRepo
{
    public class AuthorRepo(AppDbContext _db) : IAuthorRepo
    {
        public async Task<Author> AddAsync(Author author)
        {
            await _db.Authors.AddAsync(author);
            await _db.SaveChangesAsync();
            return author;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var author = await _db.Authors
                .FirstOrDefaultAsync(x => x.Id == id);

            if (author is null)
            {
                return false;
            }

            author.IsDeleted = true;
            author.ModifyDate = DateTime.UtcNow;

            await _db.SaveChangesAsync();

            return true;
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

        public async Task<bool> UpdateAsync(Author author)
        {
            var existingAuthor = await _db.Authors
                .FirstOrDefaultAsync(x => x.Id == author.Id);

            if (existingAuthor is null)
            {
                return false;
            }

            existingAuthor.Name = author.Name;
            existingAuthor.ModifyDate = DateTime.UtcNow;

            await _db.SaveChangesAsync();

            return true;
        }
    }
}
