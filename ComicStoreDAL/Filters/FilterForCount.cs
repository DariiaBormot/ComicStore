using ComicStoreDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicStoreDAL.Filters
{
    public class FilterForCount : BaseFilter<ComicBook>
    {
        public FilterForCount(FilterInputDAL filter)
             : base(x =>
            (string.IsNullOrEmpty(filter.Search) || x.Name.ToLower().Contains(filter.Search)) &&
            (!filter.PublisherId.HasValue || x.PublisherId == filter.PublisherId) &&
            (!filter.CategoryId.HasValue || x.CategoryId == filter.CategoryId))
        {

        }
    }
}
