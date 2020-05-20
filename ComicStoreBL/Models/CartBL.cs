using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicStoreBL.Models
{
    public class CartBL
    {
        public int RecordId { get; set; }
        public string CartId { get; set; }
        public int ComicBookId { get; set; }
        public int Count { get; set; }
        public DateTime DateCreated { get; set; }

        public ComicBookBL ComicBook { get; set; }
    }
}
