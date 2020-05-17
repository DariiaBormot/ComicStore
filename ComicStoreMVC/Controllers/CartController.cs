using AutoMapper;
using ComicStoreBL.Interfaces;
using ComicStoreBL.Models;
using ComicStoreBL.Services;
using ComicStoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace ComicStoreMVC.Controllers
{
    public class CartController : Controller
    {
        private readonly IComicBookService _bookService;
        private readonly IMailOrderProcessor _orderProcessor;
        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;

        public CartController(IComicBookService bookService, IMailOrderProcessor processor, IMapper mapper, IOrderService orderService)
        {
            _bookService = bookService;
            _orderProcessor = processor;
            _mapper = mapper;
            _orderService = orderService;
        }

        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        public RedirectToRouteResult AddToCart(Cart cart, int id, string returnUrl)
        {
            var comicBooks = _bookService.GetById(id);

            if (comicBooks != null)
            {
                cart.AddToCart(comicBooks, 1);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int id, string returnUrl)
        {
            var comicBooks = _bookService.GetById(id);

            if (comicBooks != null)
            {
                cart.RemoveFromCart(comicBooks);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        public ViewResult Checkout()
        {
            return View(new ShippingDetailsViewModel());
        }

        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetailsViewModel shippingDetails)
        {
            if (cart.GetAllProducts().Count() == 0)
            {
                ModelState.AddModelError("", "Your shopping cart is empty!");
            }

            if (ModelState.IsValid)
            {
                var order = new OrderViewModel();
                TryUpdateModel(order);
                var userID = User.Identity.GetUserId();

                try
                {
                    order.OrderDate = DateTime.Now;
                    order.OrderStatus = Common.Enums.OrderStatus.Processing;
                    order.TotalPrice = cart.GetTotalPrice();
                    order.UserId = userID;
                }
                catch
                {
                    // Invalid - throw exeption
                    return View(shippingDetails);
                }

                var orderBL = _mapper.Map<OrderBL>(order);
                var model = _orderService.CreateGetCreatedItem(orderBL);
                cart.CreateOrderDetails(model);
                var shippingDet = _mapper.Map<ShippingDetailsBL>(shippingDetails);
                _orderProcessor.SendEmail(cart, shippingDet);

                cart.EmptyCart();

                return View("Completed");

            }
            else
            {
                return View(shippingDetails);
            }
        }

        public ViewResult Completed()
        {
            return View();
        }

    }
}