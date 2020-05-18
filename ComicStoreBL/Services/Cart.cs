using AutoMapper;
using ComicStoreBL.Models;
using ComicStoreDAL.Entities;
using ComicStoreDAL.Interfaces;
using ComicStoreDAL.Repositories;
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
        private readonly IGenericRepository<OrderDetails> _orderDetailsRepository;
        public Cart()
        {
            CartCollection = new List<CartLine>();
            _orderDetailsRepository = new OrderDetailsRepository( new ComicStoreDAL.ComicStoreContext());
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

        public IEnumerable<CartLine> GetAllProducts()
        {
            return CartCollection;
        }

        public void CreateOrderDetails(OrderBL order)
        {

            var cartItems = GetAllProducts();

            foreach (var item in cartItems)
            {
                var orderDetail = new OrderDetails
                {
                    ComicBookId = item.ComicBookBL.Id,
                    BookPrice = item.ComicBookBL.Price,
                    OrderId = order.Id,
                    BookName = item.ComicBookBL.Name,
                    Quantity = item.Quantity
                };
                _orderDetailsRepository.Create(orderDetail);

            }
        }
    }

    public class CartLine
    {
        public ComicBookBL ComicBookBL { get; set; }
        public int Quantity { get; set; }
    }
}
