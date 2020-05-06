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
        public FilterImplementation(string sort, int? publisherId, int? categoryId)
            : base(x =>
            (!publisherId.HasValue || x.PublisherId == publisherId) &&
            (!categoryId.HasValue || x.CategoryId == categoryId))
        {
            AddInclude(x => x.Category);
            AddInclude(x => x.Publisher);
            AddOrderBy(x => x.Name);

            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
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
