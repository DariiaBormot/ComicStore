﻿using ComicStoreDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicStoreDAL.Entities
{
    public class ComicBook 
    {
        public ComicBook()
        {
            Orders = new List<OrderDetails>();
            //Carts = new List<Cart>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        public int PublisherId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Publisher Publisher { get; set; }
        public virtual ICollection<OrderDetails> Orders { get; set; }
        //public virtual ICollection<Cart> Carts { get; set; } 
    }
}
