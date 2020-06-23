using ComicStoreDAL.Entities;
using ComicStoreDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicStoreDAL
{
    public class ComicStoreContext : DbContext
    {
        public ComicStoreContext() 
        {
          // Database.SetInitializer<ComicStoreContext>(new StoreInitializer());
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<ComicBook> ComicBooks { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Cart> Carts { get; set; }

    }
}
