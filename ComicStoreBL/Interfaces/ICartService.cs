using ComicStoreBL.Models;
using ComicStoreBL.Services;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace ComicStoreBL.Interfaces
{
    public interface ICartService
    {
        CartService GetCart(HttpContextBase context);
        CartService GetCart(Controller controller);
        void AddToCart(ComicBookBL book);
        CartBL GetById(int id);
        int RemoveFromCart(int id);
        void EmptyCart();
        IEnumerable<CartBL> GetCartItems();
        int GetCount();
        double GetTotalPrice();
        void CreateOrder(OrderBL order);
        string GetCartId(HttpContextBase context);
        void MigrateCart(string userName);

    }
}