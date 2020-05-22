using AutoMapper;
using ComicStoreBL.Interfaces;
using ComicStoreBL.Models;
using ComicStoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComicStoreMVC.Controllers
{
    public class PublishersController : Controller
    {
        private readonly IPublisherService _service;
        private readonly IMapper _mapper;
        public PublishersController(IPublisherService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var publishersBL = _service.GetAll();
            var publishersPL = _mapper.Map<IEnumerable<PublisherViewModel>>(publishersBL);
            return View(publishersPL);

        }

        public ActionResult Details(int id)
        {
            var publisherBL = _service.GetById(id);
            var publisherPL = _mapper.Map<PublisherViewModel>(publisherBL);
            return View(publisherPL);
        }
        //[Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }
        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(PublisherViewModel model)
        {
            if (ModelState.IsValid)
            {
                var publisherPL = _mapper.Map<PublisherBL>(model);
                _service.Create(publisherPL);

                return RedirectToAction("Index", "Publishers");
            }
            else
            {
                return View(model);
            }
        }
        //[Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            var publisherBL = _service.GetById(id);
            var publisherPL = _mapper.Map<PublisherViewModel>(publisherBL);
            return View(publisherPL);
        }
        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Edit(int id, PublisherViewModel model)
        {
            if (ModelState.IsValid)
            {
                var publisherBL = _mapper.Map<PublisherBL>(model);
                _service.Update(publisherBL);
                return RedirectToAction("Index", "Publishers");
            }
            else
            {
                return View(model);
            }
        }

        //[Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            var publisherBL = _service.GetById(id);
            var publisherPL = _mapper.Map<PublisherViewModel>(publisherBL);
            return View(publisherPL);
        }
        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Delete(int id, FormCollection notUsed)
        {
            _service.Delete(id);
            TempData["message"] = string.Format("successfully deleted");
            return RedirectToAction("Index", "Publishers");
        }
    }
}
