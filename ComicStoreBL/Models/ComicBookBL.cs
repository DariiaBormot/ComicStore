using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicStoreBL.Models
{
    public class ComicBookBL
    {
        public ComicBookBL()
        {
            Orders = new List<OrderDetailsBL>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        public int PublisherId { get; set; }

        public CategoryBL Category { get; set; }
        public PublisherBL Publisher { get; set; }
        public IEnumerable<OrderDetailsBL> Orders { get; set; }

    }
}
