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
using ComicStoreDAL.Filters;
using ComicStoreDAL.Repositories;

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
            int pageSize = 8;
            int pageNumber = (page ?? 1);

            var comicBooksBL = _service.GetAll();
            var comicBooksPL = _mapper.Map<IEnumerable<ComicBookViewModel>>(comicBooksBL);
            return View(comicBooksPL.ToPagedList(pageNumber, pageSize));

        }


        public PartialViewResult ComicBooksList(FilterModel filter)
        {
            int pageSize = 8;
            int pageNumber = (filter.Page ?? 1);

            var filterBL = _mapper.Map<FilterInputBL>(filter);
            var filteredBooksBL = _service.GetListByFilter(filterBL);
            var filteredBooksPL = _mapper.Map<IEnumerable<ComicBookViewModel>>(filteredBooksBL);
   
            return PartialView(filteredBooksPL.ToPagedList(pageNumber, pageSize));
        }


        public ActionResult Details(int id)
        {
            var comicBL = _service.GetById(id);
            var comicPL = _mapper.Map<ComicBookViewModel>(comicBL);
            return View(comicPL);
        }

        //[Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(ComicBookViewModel newBook)
        {
            if (ModelState.IsValid)
            {
                var comicBookBL = _mapper.Map<ComicBookBL>(newBook);
                _service.Create(comicBookBL);

                return RedirectToAction("ComicBooks", "Admin");
            }
            else
            {
                return View(newBook);
            }

        }

        //[Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            return View();
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Edit(int id, ComicBookViewModel modelToUpdate)
        {
            if (ModelState.IsValid)
            {
                var comicBookBL = _mapper.Map<ComicBookBL>(modelToUpdate);
                _service.Update(comicBookBL);
                TempData["message"] = string.Format("changes were successfully saved");
                return RedirectToAction("ComicBooks", "Admin");
            }
            else
            {
                return View(modelToUpdate);
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
            return RedirectToAction("ComicBooks", "Admin");

        }
    }
}
