using AutoMapper;
using ComicStoreBL.Interfaces;
using ComicStoreBL.Models;
using ComicStoreDAL.Entities;
using ComicStoreDAL.Interfaces;
using ComicStoreDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ComicStoreBL.Services
{
    public class CartService : ICartService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<OrderDetails> _orderDetailsRepository;
        private readonly ICartRepository _cartRepository;
        public const string CartSessionKey = "CartId";
        private string ShoppingCartId { get; set; }
        public CartService(IMapper mapper, IGenericRepository<OrderDetails> orderDetailsRepository, ICartRepository cartRepository)
        {
            _orderDetailsRepository = orderDetailsRepository;
            _mapper = mapper;
            _cartRepository = cartRepository;
        }

        public CartService GetCart(HttpContextBase context)
        {
            var cart = new CartService(_mapper, _orderDetailsRepository, _cartRepository);
            cart.ShoppingCartId = cart.GetCartId(context);
            return cart;
        }

        public CartService GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }
        public void AddToCart(ComicBookBL book)
        {

            var bookDAL = _mapper.Map<ComicBook>(book);

            var cartItemDAL = _cartRepository.GetMatchingCart(ShoppingCartId, bookDAL);

            if (cartItemDAL != null)
            {
                var cartItem = _mapper.Map<CartBL>(cartItemDAL);

                cartItem.Count++;

                var itemToUpdate = _mapper.Map<Cart>(cartItem);

                _cartRepository.UpdateCount(itemToUpdate);

            }
            else
            {
                var cartItem = new CartBL
                {
                    ComicBookId = book.Id,
                    CartId = ShoppingCartId,
                    Count = 1,
                    DateCreated = DateTime.Now,
                };

                var cartToCreate = _mapper.Map<Cart>(cartItem);
                _cartRepository.Create(cartToCreate);

            }

        }

        public CartBL GetById(int id)
        {
            var cartItem = _cartRepository.GetById(id);
            var cartBL = _mapper.Map<CartBL>(cartItem);
            return cartBL;
        }

        public int RemoveFromCart(int id)
        {
            var cartItem = _cartRepository.GetById(id, ShoppingCartId);

            int itemCount = 0;

            if (cartItem != null)
            {

                if (cartItem.Count > 1)
                {
                    cartItem.Count--;

                    var itemToUpdate = _mapper.Map<Cart>(cartItem);

                    _cartRepository.UpdateCount(itemToUpdate);

                    itemCount = cartItem.Count;
                }
                else
                {
                    var itemToRemove = _mapper.Map<Cart>(cartItem);
                    _cartRepository.Delete(itemToRemove);
                }

            }
            return itemCount;
        }
        public void EmptyCart()
        {
            _cartRepository.EmptyCart(ShoppingCartId);
        }

        public IEnumerable<CartBL> GetCartItems()
        {
            var cartItemsDAL = _cartRepository.GetCartItems(ShoppingCartId);
            var cartItemsBL = _mapper.Map<IEnumerable<CartBL>>(cartItemsDAL);
            return cartItemsBL;
        }

        public int GetCount()
        {
            var count = _cartRepository.GetCount(ShoppingCartId);
            return count;
        }

        public double GetTotalPrice()
        {
            var total = _cartRepository.GetTotalPrice(ShoppingCartId);
            return total;
        }

        public void CreateOrder(OrderBL order)
        {
            double orderTotal = 0;

            var cartItems = GetCartItems();

            foreach (var item in cartItems)
            {
                var orderDetail = new OrderDetailsBL
                {
                    BookName = item.ComicBook.Name,
                    BookPrice = item.ComicBook.Price,
                    ComicBookId = item.ComicBookId,
                    OrderId = order.Id,
                    Quantity = item.Count
                };

                orderTotal += (item.Count * item.ComicBook.Price);
                var itemToCreate = _mapper.Map<OrderDetails>(orderDetail);
                _orderDetailsRepository.Create(itemToCreate);

            }

            order.TotalPrice = orderTotal;

            EmptyCart();

        }

        public string GetCartId(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] =
                        context.User.Identity.Name;
                }
                else
                {
                    Guid tempCartId = Guid.NewGuid();
                    context.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return context.Session[CartSessionKey].ToString();
        }

        // When a user has logged in, migrate their shopping cart
        public void MigrateCart(string userName)
        {
            _cartRepository.MigrateCart(userName, ShoppingCartId);
        }
    }
}
