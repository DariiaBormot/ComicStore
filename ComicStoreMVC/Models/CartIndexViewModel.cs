using ComicStoreBL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComicStoreMVC.Models
{
    public class CartIndexViewModel
    {
        public CartService CartService { get; set; }
        public string ReturnUrl { get; set; }
    }
}