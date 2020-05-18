using AutoMapper;
using ComicStoreBL.Interfaces;
using ComicStoreBL.Models;
using ComicStoreDAL.Filters;
using ComicStoreMVC.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComicStoreMVC.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderService _service;
        private readonly IMapper _mapper;
        private readonly IOrderDetailsService _orderDetailsService;
        public OrdersController(IOrderService service, IMapper mapper, IOrderDetailsService orderDetailsService)
        {
            _service = service;
            _mapper = mapper;
            _orderDetailsService = orderDetailsService;
        }
        // GET: Orders
        public ActionResult Index()
        {
            var ordersBL = _service.GetAll();
            var ordersPL = _mapper.Map<IEnumerable<OrderViewModel>>(ordersBL);
            return View(ordersPL);

        }

        public ActionResult GetOrderDetailsByOrderId(int? page, int? id)
        {
            int pageSize = 8;
            int pageNumber = (page ?? 1);

            var orderDetails = _orderDetailsService.GetOrderDetailsByOrderId(id);
            var orderDetailsPL = _mapper.Map<IEnumerable<OrderDetailsViewModel>>(orderDetails);

            return PartialView(orderDetailsPL.ToPagedList(pageNumber, pageSize));
        }


        public ViewResult GetOrdersByEmail(OrderFilterViewModel filter)
        {
            int pageSize = 8;
            int page = filter.Page;

            var filterBL = _mapper.Map<OrderFilterModelBL>(filter);
            var ordersBL = _service.GetListByFilter(filterBL);

            var filteredOrders = _mapper.Map<IEnumerable<OrderViewModel>>(ordersBL);
            var count = _service.CountFilteredItems(filterBL);

            var resultAsPagedList = new StaticPagedList<OrderViewModel>(filteredOrders, page, pageSize, count);

            return View(resultAsPagedList);
        }


        public ActionResult Details(int id)
        {
            var ordersBL = _service.GetById(id);
            var ordersPL = _mapper.Map<OrderViewModel>(ordersBL);
            return View(ordersPL);
        }

        //[Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(OrderViewModel newOrder)
        {
            if (ModelState.IsValid)
            {
                var orderPL = _mapper.Map<OrderBL>(newOrder);
                _service.Create(orderPL);

                return RedirectToAction("Orders", "Admin");
            }
            else
            {
                return View(newOrder);
            }

        }
        //[Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            return View();
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Edit(int id, OrderViewModel orderToUpdate)
        {
            if (ModelState.IsValid)
            {
                var orderPL = _mapper.Map<OrderBL>(orderToUpdate);
                _service.Update(orderPL);
                TempData["message"] = string.Format("changes were successfully saved");
                return RedirectToAction("Orders", "Admin");
            }
            else
            {
                return View(orderToUpdate);
            }
        }
        //[Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            return View();
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Delete(int id, FormCollection fcNotUsed)
        {

            _service.Delete(id);
            TempData["message"] = string.Format("successfully deleted");
            return RedirectToAction("Orders", "Admin");

        }

    }
}
