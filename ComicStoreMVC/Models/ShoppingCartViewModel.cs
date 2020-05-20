using ComicStoreBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComicStoreMVC.Models
{
    public class ShoppingCartViewModel
    {
        public IEnumerable<CartBL> CartItems { get; set; }
        public double CartTotal { get; set; }
    }
}