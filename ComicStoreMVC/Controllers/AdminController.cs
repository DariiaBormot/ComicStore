using AutoMapper;
using ComicStoreBL.Interfaces;
using ComicStoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComicStoreMVC.Controllers
{
    public class AdminController : Controller
    {
        private readonly IComicBookService _booksService;
        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;

        public AdminController(IComicBookService service, IOrderService orderService, IMapper mapper)
        {
            _booksService = service;
            _mapper = mapper;
            _orderService = orderService;
        }

        public ActionResult ComicBooks()
        {
            var comicBooksBL = _booksService.GetAll();
            var comicBooksPL = _mapper.Map<IEnumerable<ComicBookViewModel>>(comicBooksBL);

            return View(comicBooksPL);
        }

        public ActionResult Orders()
        {
            var oordersBL = _orderService.GetAll();
            var oordersPL = _mapper.Map<IEnumerable<OrderViewModel>>(oordersBL);

            return View(oordersPL);
        }

    }
}