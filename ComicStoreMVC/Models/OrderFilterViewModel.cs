﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComicStoreMVC.Models
{
    public class OrderFilterViewModel
    {
        private int MaxPageSize = 50;
        public int Page { get; set; } = 1;

        private int _pageSize = 8;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }
        private string _search;
        public string Search
        {
            get => _search;
            set => _search = value.ToLower();
        }
    }
}