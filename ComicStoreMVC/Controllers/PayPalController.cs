using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComicStoreMVC.App_Start;
using NLog;
using AutoMapper;
using ComicStoreBL.Interfaces;
using ComicStoreMVC.Models;

namespace ComicStoreMVC.Controllers
{
    public class PayPalController : Controller
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        private readonly IMapper _mapper;
        private readonly ICartService _cartService;

        public PayPalController(IMapper mapper, ICartService cartService)
        {
            _mapper = mapper;
            _cartService = cartService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PaymentWithPaypal(string Cancel = null)
        {

            APIContext apiContext = PaypalConfiguration.GetAPIContext();
            try
            {
                string payerId = Request.Params["PayerID"];
                if (string.IsNullOrEmpty(payerId))
                {
                    string baseURI = Request.Url.Scheme + "://" + Request.Url.Authority + "/Paypal/PaymentWithPayPal?";

                    var guid = Convert.ToString((new Random()).Next(100000));

                    var createdPayment = this.CreatePayment(apiContext, baseURI + "guid=" + guid);

                    var links = createdPayment.links.GetEnumerator();
                    string paypalRedirectUrl = null;
                    while (links.MoveNext())
                    {
                        Links lnk = links.Current;
                        if (lnk.rel.ToLower().Trim().Equals("approval_url"))
                        {
                            paypalRedirectUrl = lnk.href;
                        }
                    }

                    Session.Add(guid, createdPayment.id);
                    return Redirect(paypalRedirectUrl);
                }
                else
                {
                    var guid = Request.Params["guid"];
                    var executedPayment = ExecutePayment(apiContext, payerId, Session[guid] as string);
  
                    if (executedPayment.state.ToLower() != "approved")
                    {
                        return View("FailureView");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                return View("FailureView");
            }

            return View("SuccessView");
        }

        private PayPal.Api.Payment payment;
        private Payment ExecutePayment(APIContext apiContext, string payerId, string paymentId)
        {
            var paymentExecution = new PaymentExecution()
            {
                payer_id = payerId
            };
            this.payment = new Payment()
            {
                id = paymentId
            };
            return this.payment.Execute(apiContext, paymentExecution);
        }
        private Payment CreatePayment(APIContext apiContext, string redirectUrl)
        {
            var itemList = new ItemList()
            {
                items = new List<Item>()
            };

            var cart = _cartService.GetCart(this.HttpContext);

            var myOrderList = cart.GetCartItems();

            foreach (var item in myOrderList)
            {
                itemList.items.Add(new Item()
                {
                    name = item.ComicBook.Name,
                    currency = "USD",
                    price = item.ComicBook.Price.ToString(),
                    quantity = item.Count.ToString(),
                    sku = "sku"
                });
            }


            var payer = new Payer()
            {
                payment_method = "paypal"
            };

            var redirUrls = new RedirectUrls()
            {
                cancel_url = redirectUrl + "&Cancel=true",
                return_url = redirectUrl
            };

            var details = new Details()
            {
                tax = "0",
                shipping = "0",
                subtotal = cart.GetTotalPrice().ToString()
            };

            var amount = new Amount()
            {
                currency = "USD",
                total = cart.GetTotalPrice().ToString(),
                details = details
            };

            var transactionList = new List<Transaction>();

            var rnd = new Random();
            transactionList.Add(new Transaction()
            {

                description = "Transaction description",
                invoice_number = rnd.Next(1000, 9000).ToString(),
                amount = amount,
                item_list = itemList
            });

            this.payment = new Payment()
            {
                intent = "sale",
                payer = payer,
                transactions = transactionList,
                redirect_urls = redirUrls
            };

            cart.EmptyCart();

            return this.payment.Create(apiContext);
        }

        public ViewResult SuccessView()
        {
            return View();
        }

        public ViewResult FailureView()
        {
            return View();
        }

    }
}