using AutoMapper;
using ComicStoreBL.Interfaces;
using ComicStoreMVC.Filters;
using ComicStoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComicStoreMVC.Controllers
{
    [LogErrors]
    public class NavigationController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private readonly IPublisherService _publisherService;
        public NavigationController(ICategoryService service, IPublisherService publisher, IMapper mapper)
        {
            _categoryService = service;
            _mapper = mapper;
            _publisherService = publisher;
        }

        public PartialViewResult MenuByCategorie()
        {
            var categoriesBL = _categoryService.GetAll();
            var categoriesPL = _mapper.Map<IEnumerable<CategoryViewModel>>(categoriesBL);
            return PartialView(categoriesPL);
        }

        public PartialViewResult MenuByPublisher()
        {
            var publishersBL = _publisherService.GetAll();
            var publishersPL = _mapper.Map<IEnumerable<PublisherViewModel>>(publishersBL);
            return PartialView(publishersPL);
        }
    }
}
