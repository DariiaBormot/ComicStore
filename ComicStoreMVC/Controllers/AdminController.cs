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
            var filteredBooksBL = _booksService.GetListByFilter(filterBL);

            var filteredBooksPL = _mapper.Map<IEnumerable<ComicBookIncludeNavPropViewModel>>(filteredBooksBL);
            var count = _booksService.CountFilteredItems(filterBL);

            var resultAsPagedList = new StaticPagedList<ComicBookIncludeNavPropViewModel>(filteredBooksPL, page, pageSize, count);

            return View(resultAsPagedList);

        }

        public ActionResult Orders()
        {
            var oordersBL = _orderService.GetAll();
            var oordersPL = _mapper.Map<IEnumerable<OrderViewModel>>(oordersBL);

            return View(oordersPL);
        }

        public ActionResult GetUsers()
        {
            var users = _context.Users.ToList();
            return View(users);
        }



    }
}