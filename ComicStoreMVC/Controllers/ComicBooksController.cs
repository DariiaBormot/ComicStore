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
using System.Web.UI.WebControls;
using NLog;
using ComicStoreMVC.Filters;

namespace ComicStoreMVC.Controllers
{
    [HandleError]
    [LogErrors]
    public class ComicBooksController : Controller
    {

        private readonly IComicBookService _service;
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        private readonly IPublisherService _publisherService;
        public ComicBooksController(IComicBookService service, IMapper mapper, ICategoryService categoryService, IPublisherService publisherService)
        {
            _service = service;
            _mapper = mapper;
            _categoryService = categoryService;
            _publisherService = publisherService;
        }

        public ViewResult List(Models.ComicBookFilterModel filter)
        {

            var filterBL = _mapper.Map<ComicBookFilterModelBL>(filter);
            var filteredBooksBL = _service.GetBooksByFilter(filterBL);
            var filteredBooksPL = _mapper.Map<IEnumerable<ComicBookViewModel>>(filteredBooksBL);
            var count = _service.CountPageItems(filterBL);

            var resultAsPagedList = new StaticPagedList<ComicBookViewModel>(filteredBooksPL, filter.Page, filter.PageSize, count);

            return View(resultAsPagedList);

        }

        public ActionResult Details(int id)
        {
            var comicBL = _service.GetById(id);
            var comicPL = _mapper.Map<ComicBookIncludeNavPropViewModel>(comicBL);
            return View(comicPL);

        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Create()
        {
            var categories = _categoryService.GetAll();
            var categoriesPL = _mapper.Map<IEnumerable<CategoryViewModel>>(categories);

            var publishers = _publisherService.GetAll();
            var publishersPL = _mapper.Map<IEnumerable<PublisherViewModel>>(publishers);

            var comicBook = new ComicBookCreateViewModel
            {
                Categories = categoriesPL.ToList(),
                Publishers = publishersPL.ToList()
            };

            return View(comicBook);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(ComicBookCreateViewModel newBook)
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

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var comicBL = _service.GetById(id);
            var comicBook = _mapper.Map<ComicBookCreateViewModel>(comicBL);

            var categories = _categoryService.GetAll();
            var categoriesPL = _mapper.Map<IEnumerable<CategoryViewModel>>(categories);

            var publishers = _publisherService.GetAll();
            var publishersPL = _mapper.Map<IEnumerable<PublisherViewModel>>(publishers);

            comicBook.Categories = categoriesPL.ToList();
            comicBook.Publishers = publishersPL.ToList();

            return View(comicBook);

        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Edit(int id, ComicBookCreateViewModel modelToUpdate)
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

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            var comicBL = _service.GetById(id);
            var comicPL = _mapper.Map<ComicBookIncludeNavPropViewModel>(comicBL);
            return View(comicPL);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Delete(int id, FormCollection fcNotUsed)
        {

            _service.Delete(id);
            return RedirectToAction("ComicBooks", "Admin");

        }
    }
}
