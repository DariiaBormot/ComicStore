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
            OrderDetails = new List<OrderDetails>();
        }
        public int Id { get; set; }
        public double TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public string UserId { get; set; }

        public virtual ICollection<ComicBook> ComicBooks { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
