using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicStoreDAL.Entities
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public int ComicBookId { get; set; }
        public int OrderId { get; set; }
        public double BookPrice { get; set; }
        public string BookName { get; set; }

        public virtual Order Order { get; set; }
        public virtual ComicBook ComicBook { get; set; }

    }
}
