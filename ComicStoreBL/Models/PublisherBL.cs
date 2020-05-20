using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicStoreBL.Models
{
    public class PublisherBL
    {
        public PublisherBL()
        {
            ComicBooks = new List<ComicBookBL>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<ComicBookBL> ComicBooks { get; set; }
    }
}
