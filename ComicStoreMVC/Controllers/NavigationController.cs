using AutoMapper;
using ComicStoreBL.Interfaces;
using ComicStoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComicStoreMVC.Controllers
{
    public class NavigationController : Controller
    {
        private ICategoryService _service;
        private IMapper _mapper;
        public NavigationController(ICategoryService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public PartialViewResult MenuByCategorie()
        {
            var categoriesBL = _service.GetAll();
            var categoriesPL = _mapper.Map<IEnumerable<CategoryViewModel>>(categoriesBL);
            return PartialView(categoriesPL);
        }
    }
}
