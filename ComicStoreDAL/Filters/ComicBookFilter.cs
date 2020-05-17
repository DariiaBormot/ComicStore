using ComicStoreDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicStoreDAL.Filters
{
    public class ComicBookFilter : BaseFilter<ComicBook>
    {
        public ComicBookFilter(FilterInputDAL filter)
            : base(x =>
            (string.IsNullOrEmpty(filter.Search) || x.Name.ToLower().Contains(filter.Search)) &&
            (!filter.PublisherId.HasValue || x.PublisherId == filter.PublisherId) &&
            (!filter.CategoryId.HasValue || x.CategoryId == filter.CategoryId))
        {
            AddInclude(x => x.Category);
            AddInclude(x => x.Publisher);
            AddOrderBy(x => x.Name);
            ApplyPaging(filter.PageSize * (filter.Page - 1), filter.PageSize);

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

        public ComicBookFilter(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.Category);
            AddInclude(x => x.Publisher);
        }

    }
}
