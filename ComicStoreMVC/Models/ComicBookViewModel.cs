using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComicStoreMVC.Models
{
    public class ComicBookViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        [Display(Name = "Publisher")]
        public int PublisherId { get; set; }
    }
}