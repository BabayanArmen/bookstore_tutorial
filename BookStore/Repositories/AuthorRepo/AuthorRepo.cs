using BookStore.Data;
using BookStore.Entities;
using BookStore.FIlters;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using static System.Net.WebRequestMethods;

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

        public async Task<PageResult<Author>> GetAllAsync(AuthorFilter filter)
        {
            var query = _db.Authors
                .Include(x => x.Books)
                .Include(x => x.AuthorPublishers)
                .AsQueryable();

            var filteredQuery = filter.Apply(query);

            var totalRecords = await filteredQuery.CountAsync();

            var pageSize = Math.Clamp(filter.Take, 1, 100);

            var pageNumber = Math.Max(filter.Skip, 1);
            
            var autors = await filteredQuery
                .OrderBy(x => x.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PageResult<List<Author>>
            {
                Data = autors,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalRecords = totalRecords,
                TotalPages = (int)Math.Ceiling(totalRecords / (double)pageSize)
            };
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



//var query = filter.Apply(_db.Authors);

//var totalRecords = await query.CountAsync();

//var pageSize = Math.Clamp(filter.PageSize, 1, 100);
//var pageNumber = Math.Max(filter.PageNumber, 1);

//var authors = await query
//    .OrderBy(x => x.Id)
//    .Skip((pageNumber - 1) * pageSize)
//    .Take(pageSize)
//    .ToListAsync();

//return new PagedResult<Author>
//{
//    Items = authors,
//    TotalRecords = totalRecords,
//    TotalPages = (int)Math.Ceiling(totalRecords / (double)pageSize),
//    PageNumber = pageNumber,
//    PageSize = pageSize
//};