using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicStoreBL.Models
{
    public class OrderDetailsBL
    {
        public int Id { get; set; }
        public int ComicBookId { get; set; }
        public double BookPrice { get; set; }
        public string BookName { get; set; }
        public int OrderId { get; set; }

    }
}
