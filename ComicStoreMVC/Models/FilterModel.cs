using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComicStoreMVC.Models
{
    public class FilterModel
    {
        private int MaxPageSize = 50;
        //public int? Page { get; set; }

        private int _pageSize = 8;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }
        public string Sort { get; set; }
        public int? PublisherId { get; set; }
        public int? CategoryId { get; set; }
        public int Page { get; set; } = 1; 
        private string _search;
        public string Search 
        {
            get => _search;
            set => _search = value.ToLower(); 
        }
    }
}