using BookStore.Entities;
using BookStore.FIlters;
using static System.Net.WebRequestMethods;

namespace BookStore.FIlters
{
    public class AuthorFilter : BaseFilter<Author>
    {
        public string? Name { get; set; }

        public override IQueryable<Author> Apply(IQueryable<Author> query)
        {
            query = base.Apply(query);

            if (!string.IsNullOrWhiteSpace(Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(Name.ToLower()));
            }

            return query
                .OrderBy(x => x.Id)
                .Skip((Skip - 1) * Take)
                .Take(Take);
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