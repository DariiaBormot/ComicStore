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
    public class AdminController : Controller
    {
        private readonly IComicBookService _service;
        private readonly IMapper _mapper;

        public AdminController(IComicBookService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public ActionResult ComicBooks()
        {
            var comicBooksBL = _service.GetAll();
            var comicBooksPL = _mapper.Map<IEnumerable<ComicBookViewModel>>(comicBooksBL);

            return View(comicBooksPL);
        }

    }
}