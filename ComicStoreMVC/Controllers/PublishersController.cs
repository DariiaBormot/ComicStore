﻿using AutoMapper;
using ComicStoreBL.Interfaces;
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
        // GET: Publishers
        public ActionResult Index()
        {
            var publishersBL = _service.GetAll();
            var publishersPL = _mapper.Map<IEnumerable<PublisherViewModel>>(publishersBL);
            return View(publishersPL);
        }

        // GET: Publishers/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Publishers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Publishers/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Publishers/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Publishers/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Publishers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Publishers/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
