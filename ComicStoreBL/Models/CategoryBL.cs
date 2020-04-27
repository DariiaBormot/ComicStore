using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicStoreBL.Models
{
    public class CategoryBL
    {
        public CategoryBL()
        {
            ComicBooks = new List<ComicBookBL>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public IEnumerable<ComicBookBL> ComicBooks { get; set; }
    }
}
