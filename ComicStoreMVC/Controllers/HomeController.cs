using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using ComicStoreMVC.Models;
using ComicStoreMVC.Filters;
using ComicStoreBL.Interfaces;
using AutoMapper;
using ComicStoreBL.Models;

namespace ComicStoreMVC.Controllers
{
    [HandleError]
    [LogErrors]
    public class HomeController : Controller
    {
        private readonly IContactUs _contactUs;
        private readonly IMapper _mapper;
        public HomeController(IContactUs contactUs, IMapper mapper)
        {
            _contactUs = contactUs;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(EmailFormModel model)
        {
            if (ModelState.IsValid)
            {
                var mailFormBL = _mapper.Map<MailFormBL>(model);
                await _contactUs.SendMailAsync(mailFormBL);

                return RedirectToAction("Sent");
            }
            return View(model);
        }

        public ActionResult Sent()
        {
            return View();
        }
    }
}