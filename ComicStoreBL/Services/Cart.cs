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
        private readonly List<CartLine> CartCollection;

        public Cart()
        {
            CartCollection = new List<CartLine>();
        }
        public void AddToCart(ComicBookBL book, int quantity)
        {
            var line = CartCollection
                .Where(g => g.ComicBookBL.Id == book.Id)
                .FirstOrDefault();

            if (line == null)
            {
                CartCollection.Add(new CartLine
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
            CartCollection.RemoveAll(x => x.ComicBookBL.Id == book.Id);
        }

        public double GetTotalPrice()
        {

            return CartCollection.Sum(x => x.ComicBookBL.Price * x.Quantity);

        }
        public void EmptyCart()
        {
            CartCollection.Clear();
        }

        public IEnumerable<CartLine> GetAllProducts
        {
            get { return CartCollection; }
        }
    }

    public class CartLine
    {
        public ComicBookBL ComicBookBL { get; set; }
        public int Quantity { get; set; }
    }
}
