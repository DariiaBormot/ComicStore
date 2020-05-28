using ComicStoreDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicStoreDAL.Filters
{
    public class CountOrdersFilter : BaseFilter<Order>
    {
        public CountOrdersFilter(OrderFilterModel filter)
        : base(x =>
        (string.IsNullOrEmpty(filter.Search) || x.Email.ToLower().Contains(filter.Search)))

        { }
    }
}
