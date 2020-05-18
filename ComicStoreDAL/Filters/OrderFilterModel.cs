using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicStoreDAL.Filters
{
    public class OrderFilterModel
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string Search { get; set; }
    }
}
