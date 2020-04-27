using ComicStoreBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicStoreBL.Services
{
    public class Cart
    {
        private readonly List<CartLine> cartCollection = new List<CartLine>();

        public void AddToCart(ComicBookBL book, int quantity)
        {
            var line = cartCollection
                .Where(g => g.ComicBookBL.Id == book.Id)
                .FirstOrDefault();

            if (line == null)
            {
                cartCollection.Add(new CartLine
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

        public IEnumerable<CartLine> GetAllProducts
        {
            get { return cartCollection; }
        }
    }
}
