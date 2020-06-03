using AutoMapper;
using ComicStoreBL.Interfaces;
using ComicStoreBL.Services;
using ComicStoreDAL.Entities;
using ComicStoreDAL.Interfaces;
using ComicStoreMVC.Filters;
using ComicStoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComicStoreMVC.Controllers
{
    [HandleError]
    [LogErrors]
    public class ShoppingCartController : Controller
    {
        private readonly IComicBookService _bookService;
        private readonly ICartService _cartService;
        private readonly IMapper _mapper;
        public ShoppingCartController(IComicBookService bookService, ICartService cartService, IMapper mapper)
        {
            _cartService = cartService;
            _bookService = bookService;
            _mapper = mapper;

        }

        public ActionResult Index()
        {
            var cart = _cartService.GetCart(this.HttpContext);

            var cartsBL = cart.GetCartItems();
            var cartsPL = _mapper.Map<IEnumerable<CartViewModel>>(cartsBL);

            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cartsPL,
                CartTotal = cart.GetTotalPrice()
            };

            return View(viewModel);
        }

        public ActionResult AddToCart(int id)
        {
            var comicBook = _bookService.GetById(id);
            var cart = _cartService.GetCart(this.HttpContext);
            cart.AddToCart(comicBook);

            return RedirectToAction("List", "ComicBooks");
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

        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = _cartService.GetCart(this.HttpContext);

            ViewData["CartCount"] = cart.GetCount();
            return PartialView("CartSummary");
        }
    }
}