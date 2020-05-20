using AutoMapper;
using ComicStoreBL.Interfaces;
using ComicStoreBL.Services;
using ComicStoreDAL.Entities;
using ComicStoreDAL.Interfaces;
using ComicStoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComicStoreMVC.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IComicBookService _bookService;
        private readonly ICartService _cartService;
        public ShoppingCartController(IComicBookService bookService, ICartService cartService)
        {
            _cartService = cartService;
            _bookService = bookService;

        }

        public ActionResult Index()
        {
            var cart = _cartService.GetCart(this.HttpContext);

            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotalPrice()
            };

            return View(viewModel);
        }

        public ActionResult AddToCart(int id)
        {

            var comicBook = _bookService.GetById(id);
            var cart = _cartService.GetCart(this.HttpContext);
            cart.AddToCart(comicBook);

            return RedirectToAction("Index");

        }


        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {

            var cart = _cartService.GetCart(this.HttpContext);
            string bookName = _cartService.GetById(id).ComicBook.Name;
            int itemCount = cart.RemoveFromCart(id);

            var result = new ShoppingCartRemoveViewModel
            {
                Message = Server.HtmlEncode(bookName) +
                    " has been removed from your shopping cart.",
                CartTotal = cart.GetTotalPrice(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };

            return Json(result);
        }


    }
}