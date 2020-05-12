using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicStoreBL.Models
{
    public class FilterInputBL
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string Sort { get; set; }
        public int? PublisherId { get; set; }
        public int? CategoryId { get; set; }
        public int? Page { get; set; }
        public string Search { get; set; }
    }
}
