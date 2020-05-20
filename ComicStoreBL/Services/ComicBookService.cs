using AutoMapper;
using ComicStoreBL.Interfaces;
using ComicStoreBL.Models;
using ComicStoreDAL.Entities;
using ComicStoreDAL.Interfaces;
using ComicStoreDAL.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicStoreBL.Services
{
    public class ComicBookService : GenericService<ComicBookBL, ComicBook>, IComicBookService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<ComicBook> _repository;

        public ComicBookService(IGenericRepository<ComicBook> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public IEnumerable<ComicBookBL> GetBooksByFilter(ComicBookFilterModelBL filter) 
        {
            var filterDAL = _mapper.Map<ComicBookFilterModel>(filter);

            var filterImp = new ComicBookFilter(filterDAL);

            var bookListDAL = _repository.GetByFilter(filterImp);

            var booksBL = _mapper.Map<IEnumerable<ComicBookBL>>(bookListDAL);

            return booksBL;
        }
        public int CountPageItems(ComicBookFilterModelBL filter) 
        {
            var filterDAL = _mapper.Map<ComicBookFilterModel>(filter);
           
            var coutFilter = new FilterForCount(filterDAL);

            var count = _repository.Count(coutFilter);

            return count;
        }

        public override ComicBookBL Map(ComicBook entity)
        {
            return _mapper.Map<ComicBookBL>(entity);
        }

        public override ComicBook Map(ComicBookBL blmodel)
        {
            return _mapper.Map<ComicBook>(blmodel);
        }

        public override IEnumerable<ComicBookBL> Map(IList<ComicBook> entities)
        {
            return _mapper.Map<IEnumerable<ComicBookBL>>(entities);
        }

        public override IEnumerable<ComicBook> Map(IList<ComicBookBL> models)
        {
            return _mapper.Map<IEnumerable<ComicBook>>(models);
        }
    }
}
