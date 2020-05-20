using ComicStoreDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicStoreDAL.Interfaces
{
    public interface ICartRepository
    {
        Cart GetMatchingCart(string shoppingCartId, ComicBook book);
        void Create(Cart cartItem);
        void UpdateCount(Cart cartItem);
        Cart GetById(int id, string shoppingCartId);
        Cart GetById(int id);
        void Delete(Cart cart);
        void EmptyCart(string shoppingCartId);
        IEnumerable<Cart> GetCartItems(string shoppingCartId);
        int GetCount(string shoppingCartId);
        double GetTotalPrice(string shoppingCartId);
        void MigrateCart(string userName, string shoppingCartId);

    }
}
