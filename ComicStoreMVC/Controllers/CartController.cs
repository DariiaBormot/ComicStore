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

        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                CartService = GetCartService(),
                ReturnUrl = returnUrl
            });
        }

        public RedirectToRouteResult AddToCart(int bookId, string returnUrl)
        {
            var comicBooks = _bookService.GetById(bookId);

            if (comicBooks != null)
            {
                GetCartService().AddToCart(comicBooks, 1);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(int bookId, string returnUrl)
        {
            var comicBooks = _bookService.GetById(bookId);

            if (comicBooks != null)
            {
                GetCartService().RemoveFromCart(comicBooks);
            }

            return RedirectToAction("Index", new { returnUrl });
        }


        public CartService GetCartService()
        {
            var cartService = (CartService)Session["Cart"];

            if (cartService == null)
            {
                cartService = new CartService();
                Session["Cart"] = cartService;
            }

            return cartService;
        }
    }
}