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

namespace ComicStoreMVC.Controllers
{
    public class CartController : Controller
    {
        private readonly IComicBookService _bookService;
        private readonly IOrderProcessor _orderProcessor;
        private readonly IMapper _mapper;
        public CartController(IComicBookService bookService, IOrderProcessor processor, IMapper mapper)
        {
            _bookService = bookService;
            _orderProcessor = processor;
            _mapper = mapper;
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
            if (cart.GetAllProducts.Count() == 0)
            {
                ModelState.AddModelError("", "Your shopping cart is empty!");
            }

            if (ModelState.IsValid)
            {
                var shippingBL = _mapper.Map<ShippingDetailsBL>(shippingDetails);
                _orderProcessor.ProcessOrder(cart, shippingBL);
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