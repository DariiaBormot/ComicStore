using AutoMapper;
using ComicStoreBL.Interfaces;
using ComicStoreBL.Models;
using ComicStoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;

namespace ComicStoreMVC.Controllers
{
    public class ComicBooksController : Controller
    {
        private readonly IComicBookService _service;
        private readonly IMapper _mapper;
        public ComicBooksController(IComicBookService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }


        public ActionResult List(int? page)
        {
            int pageSize = 4;
            int pageNumber = (page ?? 1);

            var comicBooksBL = _service.GetAll();
            var comicBooksPL = _mapper.Map<IEnumerable<ComicBookViewModel>>(comicBooksBL);
            return View(comicBooksPL.ToPagedList(pageNumber, pageSize));

        }


        public PartialViewResult ComicBooksByCategory(int? category, int? page)
        {
            ViewBag.SelectedCategory = category;

            int pageSize = 4;
            int pageNumber = (page ?? 1);

            var comicBooksBL = _service.GetAll();
            var comicBooksPL = _mapper.Map<IEnumerable<ComicBookViewModel>>(comicBooksBL);


            if (category != null)
            {
                var booksByCategory = comicBooksPL.Where(x => x.CategoryId == category);
                return PartialView(booksByCategory.ToPagedList(pageNumber, pageSize));
            }
            else
            {
                return PartialView(comicBooksPL.ToPagedList(pageNumber, pageSize));
            }

        }



        public ActionResult Details(int id)
        {
            var comicBL = _service.GetById(id);
            var comicPL = _mapper.Map<ComicBookViewModel>(comicBL);
            return View(comicPL);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(ComicBookViewModel newBook)
        {
            if (ModelState.IsValid)
            {
                var comicBookBL = _mapper.Map<ComicBookBL>(newBook);
                _service.Create(comicBookBL);
                return RedirectToAction("Index");
            }
            else
            {
                return View(newBook);
            }

        }


        public ActionResult Edit(int id)
        {
            return View();
        }


        [HttpPost]
        public ActionResult Edit(int id, ComicBookViewModel modelToUpdate)
        {
            if (ModelState.IsValid)
            {
                var comicBookBL = _mapper.Map<ComicBookBL>(modelToUpdate);
                _service.Update(comicBookBL);
                return RedirectToAction("Index");
            }
            else
            {
                return View(modelToUpdate);
            }
        }


        public ActionResult Delete(int id)
        {
            return View();
        }


        [HttpPost]
        public ActionResult Delete(int id, FormCollection fcNotUsed)
        {

            _service.Delete(id);
            return RedirectToAction("Index");

        }
    }
}
