using ComicStoreBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicStoreBL.Services
{
    public class CartService
    {
        private readonly List<Cart> cartCollection = new List<Cart>();

        public void AddToCart(ComicBookBL book, int quantity)
        {
            var line = cartCollection
                .Where(g => g.ComicBookBL.Id == book.Id)
                .FirstOrDefault();

            if (line == null)
            {
                cartCollection.Add(new Cart
                {
                    ComicBookBL = book,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveFromCart(ComicBookBL book)
        {
            cartCollection.RemoveAll(x => x.ComicBookBL.Id == book.Id);
        }

        public double GetTotalPrice()
        {

            return cartCollection.Sum(x => x.ComicBookBL.Price * x.Quantity);

        }
        public void EmptyCart()
        {
            cartCollection.Clear();
        }

        public IEnumerable<Cart> GetAllProducts
        {
            get { return cartCollection; }
        }
    }
}
