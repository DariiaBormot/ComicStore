using AutoMapper;
using ComicStoreBL.Interfaces;
using ComicStoreBL.Models;
using ComicStoreMVC.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComicStoreMVC.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IComicBookService _booksService;
        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;
        private readonly ApplicationDbContext _context;

        public AdminController(IComicBookService service, IOrderService orderService, IMapper mapper)
        {
            _booksService = service;
            _mapper = mapper;
            _orderService = orderService;
            _context = new ApplicationDbContext();
        }

        public ActionResult ComicBooks(ComicBookFilterModel filter)
        {
            int pageSize = 8;
            int page = filter.Page;

            var filterBL = _mapper.Map<ComicBookFilterModelBL>(filter);
            var filteredBooksBL = _booksService.GetBooksByFilter(filterBL);
            var filteredBooksPL = _mapper.Map<IEnumerable<ComicBookIncludeNavPropViewModel>>(filteredBooksBL);

            var count = _booksService.CountPageItems(filterBL);
            var resultAsPagedList = new StaticPagedList<ComicBookIncludeNavPropViewModel>(filteredBooksPL, page, pageSize, count);

            return View(resultAsPagedList);

        }

        public ActionResult Orders(OrderFilterViewModel filter)
        {
            int pageSize = 8;
            int page = filter.Page;

            var filterBL = _mapper.Map<OrderFilterModelBL>(filter);
            var ordersBL = _orderService.GetOrdersByFilter(filterBL);

            var filteredOrders = _mapper.Map<IEnumerable<OrderViewModel>>(ordersBL);
            var count = _orderService.CountPageItems(filterBL);

            var resultAsPagedList = new StaticPagedList<OrderViewModel>(filteredOrders, page, pageSize, count);

            return View(resultAsPagedList);

        }

        public ActionResult GetUsers(int? page)
        {

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var users = _context.Users.ToList();
            return View(users.ToPagedList(pageNumber, pageSize));

        }

    }
}