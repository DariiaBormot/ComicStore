using ComicStoreDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicStoreDAL.Filters
{
    public class OrderFilter : BaseFilter<Order>
    {
        public OrderFilter(OrderFilterModel filter)
          : base(x =>
          (string.IsNullOrEmpty(filter.Search) || x.Email.ToLower().Contains(filter.Search)))

        {
            AddOrderBy(x => x.Name);

            ApplyPaging(filter.PageSize * (filter.Page - 1), filter.PageSize);

        }

    }
}
