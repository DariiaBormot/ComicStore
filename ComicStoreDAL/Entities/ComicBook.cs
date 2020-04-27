﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicStoreDAL.Entities
{
    public class ComicBook
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public Publisher Publisher { get; set; }
        public int PublisherId { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
