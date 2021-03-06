﻿using ComicStoreDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicStoreDAL.Entities
{
    public class Category 
    {
        public Category()
        {
            ComicBooks = new List<ComicBook>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public virtual ICollection<ComicBook> ComicBooks { get; set; }
    }
}
