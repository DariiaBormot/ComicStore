using Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicStoreDAL.Entities
{
    public class Order
    {
        public Order()
        {
            ComicBooks = new List<ComicBook>();
        }
        public int Id { get; set; }
        public double TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<ComicBook> ComicBooks { get; set; }
    }
}
