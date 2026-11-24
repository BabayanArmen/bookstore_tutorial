using BookStore.Entities;

namespace BookStore.FIlters
{
    public class BaseFilter<T> where T : BaseEntity
    {
        public int? Id { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public bool? IsDeleted { get; set; }

        public int Skip { get; set; } = 0;
        public int Take { get; set; } = 10;

        public IQueryable<T> BaseFilterApply(IQueryable<T> query)
        {
            if (Id.HasValue)
            {
                query = query.Where(x => x.Id == Id);
            }

            if (CreateDate.HasValue)
            {
                query = query.Where(x => x.CreateDate == CreateDate);
            }

            if (ModifyDate.HasValue)
            {
                query = query.Where(x => x.ModifyDate.HasValue && x.ModifyDate == ModifyDate);
            }

            if (IsDeleted.HasValue)
            {
                query = query.Where(x => x.IsDeleted == IsDeleted.Value);
            }
            else
            {
                query = query.Where(x => !x.IsDeleted);
            }

            return query;
        }

    }
}
