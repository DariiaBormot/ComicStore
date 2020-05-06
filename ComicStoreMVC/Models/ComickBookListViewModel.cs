using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComicStoreMVC.Models
{
    public class ComickBookListViewModel
    {
        public IEnumerable<ComicBookViewModel> Models { get; set; }
        public SelectList Publishers { get; set; }
        public SelectList Categories { get; set; }
    }
}