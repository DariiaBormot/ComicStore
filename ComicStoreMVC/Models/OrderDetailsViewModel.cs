using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComicStoreMVC.Models
{
    public class OrderDetailsViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        public double BookPrice { get; set; }
        public string BookName { get; set; }
        public int Quantity { get; set; }
    }
}