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
        private readonly IOrderDetailsService _orderDetailsService;
        private readonly IOrderService _orderService;

        public CartController(IComicBookService bookService, IMailOrderProcessor processor, IMapper mapper, IOrderDetailsService orderDetailsService, IOrderService orderService)
        {
            _bookService = bookService;
            _orderProcessor = processor;
            _mapper = mapper;
            _orderDetailsService = orderDetailsService;
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
            return View(new OrderDetailsViewModel());
        }

        [HttpPost]
        public ActionResult Checkout(Cart cart, OrderDetailsViewModel shippingDetails)
        {
            if (cart.GetAllProducts.Count() == 0)
            {
                ModelState.AddModelError("", "Your shopping cart is empty!");
            }

            if (ModelState.IsValid)
            {
                var userID = User.Identity.GetUserId();

                var orderDetails = new List<OrderDetailsViewModel>() { shippingDetails };

                var newOrder = new OrderViewModel()
                {
                    OrderDate = DateTime.Now,
                    OrderStatus = Common.Enums.OrderStatus.Processing,
                    TotalPrice = cart.GetTotalPrice(),
                    UserId = userID,
                    OrderDetails = orderDetails
                };

                var orderBL = _mapper.Map<OrderBL>(newOrder);

                var orderDetailsBL = _mapper.Map<OrderDetailsBL>(shippingDetails);

                _orderProcessor.SendEmail(cart, orderDetailsBL);

                _orderService.Create(orderBL);

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