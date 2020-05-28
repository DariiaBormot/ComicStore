using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComicStoreMVC.Models
{
    public class ComicBookIncludeNavPropViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public double Price { get; set; }
        public int Quantity { get; set; }

        public CategoryViewModel Category { get; set; }
        public PublisherViewModel Publisher { get; set; }
    }
}