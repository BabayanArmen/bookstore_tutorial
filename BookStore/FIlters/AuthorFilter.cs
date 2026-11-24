using BookStore.Entities;
using BookStore.Models;

namespace BookStore.FIlters
{
    public class AuthorFilter : BaseFilter<Author>
    {
        public string? Name { get; set; }

        public (IQueryable<Author>, PageInfo) Apply(IQueryable<Author> query)
        {
            query = base.BaseFilterApply(query);

            if (!string.IsNullOrWhiteSpace(Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(Name.ToLower()));
            }

            var totalRecords = query.Count();

            var pageSize = Math.Clamp(Take, 1, 100);

            var pageNumber = Math.Max(Skip, 1);

            var filteredQuery = query
                  .OrderBy(x => x.Id)
                  .Skip((pageNumber - 1) * pageSize)
                  .Take(pageSize);

            var pageInfo = new PageInfo
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalRecords = totalRecords,
                TotalPages = (int)Math.Ceiling(totalRecords / (double)pageSize)
            };

            return (filteredQuery, pageInfo);
        }
    }
}