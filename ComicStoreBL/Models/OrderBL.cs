using Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicStoreBL.Models
{
    public class OrderBL
    {
        public OrderBL()
        {
            ComicBooks = new List<ComicBookBL>();
        }
        public int Id { get; set; }
        public double TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public int UserId { get; set; }
        public IEnumerable<ComicBookBL> ComicBooks { get; set; }
    }
}
