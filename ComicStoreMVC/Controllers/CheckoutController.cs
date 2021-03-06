﻿using AutoMapper;
using ComicStoreBL.Interfaces;
using ComicStoreBL.Models;
using ComicStoreBL.Services;
using ComicStoreDAL.Entities;
using ComicStoreDAL.Interfaces;
using ComicStoreMVC.Filters;
using ComicStoreMVC.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComicStoreMVC.Controllers
{
    [HandleError]
    [LogErrors]
    public class CheckoutController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        private readonly ICartService _cartService;
        private readonly IMailOrderProcessor _orderProcessor;

        public CheckoutController(IOrderService orderService, IMapper mapper, ICartService cartService, IMailOrderProcessor orderProcessor)
        {
            _cartService = cartService;
            _orderService = orderService;
            _mapper = mapper;
            _orderProcessor = orderProcessor;
        }

        public ActionResult AddressAndPayment()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddressAndPayment(ShippingDetailsViewModel shippingDetails)
        {

            var cart = _cartService.GetCart(this.HttpContext);

            if (cart.GetCartItems().Count() == 0)
            {
                ModelState.AddModelError("", "Your shopping cart is empty!");
            }

            var order = new OrderViewModel();
            TryUpdateModel(order);

            if (ModelState.IsValid)
            {

                order.OrderDate = DateTime.Now;
                order.OrderStatus = Common.Enums.OrderStatus.Processing;
                order.TotalPrice = cart.GetTotalPrice();
                order.PaymentMethod = Common.Enums.PaymentMethod.DueOnReceipt;

                var orderBL = _mapper.Map<OrderBL>(order);
                var orderToCreate =  _orderService.CreateGetCreatedItem(orderBL);
                cart.CreateOrder(orderToCreate);
                cart.EmptyCart();

                var shippingInfo = _mapper.Map<ShippingDetailsBL>(shippingDetails);
                _orderProcessor.SendEmail(shippingInfo, cart);

                return RedirectToAction("Complete");

            }
            else
            {
                return View(shippingDetails);
            }
        }

        public ActionResult Complete()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CheckoutWithPayPal()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CheckoutWithPayPal(ShippingDetailsViewModel shippingDetails)
        {
            var cart = _cartService.GetCart(this.HttpContext);

            if (cart.GetCartItems().Count() == 0)
            {
                ModelState.AddModelError("", "Your shopping cart is empty!");
            }

            var order = new OrderViewModel();
            TryUpdateModel(order);

            if (ModelState.IsValid)
            {

                order.OrderDate = DateTime.Now;
                order.OrderStatus = Common.Enums.OrderStatus.Processing;
                order.TotalPrice = cart.GetTotalPrice();
                order.PaymentMethod = Common.Enums.PaymentMethod.PayPal;

                var orderBL = _mapper.Map<OrderBL>(order);
                var orderToCreate = _orderService.CreateGetCreatedItem(orderBL);
                cart.CreateOrder(orderToCreate);

                var shippingInfo = _mapper.Map<ShippingDetailsBL>(shippingDetails);
                _orderProcessor.SendEmail(shippingInfo, cart);

                return RedirectToAction("PaymentWithPaypal", "PayPal");

            }
            else
            {
                return View(shippingDetails);
            }
        }


    }
}