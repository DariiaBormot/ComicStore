using ComicStoreDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicStoreDAL.Filters
{
    public class FilterImplementation : BaseFilter<ComicBook>
    {
        public FilterImplementation(FilterInputDAL filter)
            : base(x =>
            (!filter.PublisherId.HasValue || x.PublisherId == filter.PublisherId) &&
            (!filter.CategoryId.HasValue || x.CategoryId == filter.CategoryId))
        {
            AddInclude(x => x.Category);
            AddInclude(x => x.Publisher);
            AddOrderBy(x => x.Name);

            if (!string.IsNullOrEmpty(filter.Sort))
            {
                switch (filter.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDecending(p => p.Price);
                        break;
                    default:
                        AddOrderBy(n => n.Name);
                        break;
                }
            }

        }

        public FilterImplementation(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.Category);
            AddInclude(x => x.Publisher);
        }

    }
}
