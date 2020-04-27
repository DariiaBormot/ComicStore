using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicStoreBL.Models
{
    public class Cart
    {
        public ComicBookBL ComicBookBL { get; set; }
        public int Quantity { get; set; }
    }
}
