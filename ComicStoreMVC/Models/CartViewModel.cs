using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComicStoreMVC.Models
{
    public class CartViewModel
    {
        public int RecordId { get; set; }
        public string CartId { get; set; }
        public int ComicBookId { get; set; }
        public int Count { get; set; }
        public DateTime DateCreated { get; set; }

        public ComicBookViewModel ComicBook { get; set; }
    }
}