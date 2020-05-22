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
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _service;
        private readonly IMapper _mapper;
        public CategoriesController(ICategoryService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }


        public ActionResult Index()
        {
            var categoriesBL = _service.GetAll();
            var categoriesPL = _mapper.Map<IEnumerable<CategoryViewModel>>(categoriesBL);
            return View(categoriesPL);
        }

        public ActionResult Details(int id)
        {
            var categoryBL = _service.GetById(id);
            var categoryPL = _mapper.Map<CategoryViewModel>(categoryBL);
            return View(categoryPL);
        }

        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var categoryPL = _mapper.Map<CategoryBL>(model);
                _service.Create(categoryPL);

                return RedirectToAction("Index", "Categories");
            }
            else
            {
                return View(model);
            }
        }

        //[Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            var categoryBL = _service.GetById(id);
            var categoryPL = _mapper.Map<CategoryViewModel>(categoryBL);
            return View(categoryPL);
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Edit(int id, CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var categoryPL = _mapper.Map<CategoryBL>(model);
                _service.Update(categoryPL);
                return RedirectToAction("Index", "Categories");
            }
            else
            {
                return View(model);
            }
        }

        //[Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            var categoryBL = _service.GetById(id);
            var categoryPL = _mapper.Map<CategoryViewModel>(categoryBL);
            return View(categoryPL);
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Delete(int id, FormCollection fcNotUsed)
        {
            _service.Delete(id);
            TempData["message"] = string.Format("successfully deleted");
            return RedirectToAction("Index", "Categories");
        }
    }
}
