using ComicStoreBL.Interfaces;
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

        public CartController(IComicBookService bookService)
        {
            _bookService = bookService;
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

    }
}