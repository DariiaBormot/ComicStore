using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComicStoreMVC.Models
{
    public class OrderDetailsViewModel
    {
        public int Id { get; set; }
        public int ComicBookId { get; set; }
        public double BookPrice { get; set; }
        public string BookName { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
    }
}