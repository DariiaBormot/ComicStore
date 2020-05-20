using ComicStoreDAL.Entities;
using ComicStoreDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicStoreDAL.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly ComicStoreContext _context;
        public CartRepository(ComicStoreContext context)
        {
            _context = context;
        }

        public Cart GetMatchingCart(string shoppingCartId, ComicBook book)
        {
            var cartItem = _context.Carts.FirstOrDefault(
                        c => c.CartId == shoppingCartId
                        && c.ComicBookId == book.Id);

            return cartItem;
        }

        public void Create(Cart cartItem)
        {
            _context.Carts.Add(cartItem);
            _context.SaveChanges();
        }

        public void UpdateCount(Cart cartItem) 
        {
            var result = _context.Carts.FirstOrDefault(x => x.RecordId == cartItem.RecordId);

            if (result != null)
            {
                result.Count = cartItem.Count;
                _context.SaveChanges();
            }
        }

        public Cart GetById(int id, string shoppingCartId)
        {
            var cartItem = _context.Carts.FirstOrDefault(
                            cart => cart.CartId == shoppingCartId
                            && cart.RecordId == id);
            return cartItem;
        }

        public Cart GetById(int id)
        {
            var cartItem = _context.Carts.FirstOrDefault(x => x.RecordId == id);
            return cartItem;
        }

        public void Delete(Cart cart)
        {
            _context.Carts.Remove(cart);
            _context.SaveChanges();
        }

        public void EmptyCart(string shoppingCartId)
        {
            var cartItems = _context.Carts.Where(cart => cart.CartId == shoppingCartId);

            foreach (var cartItem in cartItems)
            {
                _context.Carts.Remove(cartItem);
            }

            _context.SaveChanges();
        }

        public IEnumerable<Cart> GetCartItems(string shoppingCartId)
        {

           var cartItems = _context.Carts.Where(
               cart => cart.CartId == shoppingCartId).ToList();

            return cartItems;
        }

        public int GetCount(string shoppingCartId)
        {

            int? count = _context.Carts.Where(x => x.CartId == shoppingCartId)
                                       .Select(x => (int?)x.Count).Sum();

            return count ?? 0;
        }

        public double GetTotalPrice(string shoppingCartId) 
        {

            double? total = _context.Carts.Where(x => x.CartId == shoppingCartId)
                                          .Sum(x => (int?)x.Count * x.ComicBook.Price);
       
            return total ?? 0;
        }



        public void MigrateCart(string userName, string shoppingCartId)
        {
            var shoppingCart = _context.Carts.Where(c => c.CartId == shoppingCartId);

            foreach (var item in shoppingCart)
            {
                item.CartId = userName;
            }

            _context.SaveChanges();
        }

    }
}
