using ComicStoreBL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ComicStoreMVC.Models
{
    public class ShoppingCartViewModel
    {
        public IEnumerable<CartViewModel> CartItems { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public double CartTotal { get; set; }
    }
}