using AutoMapper;
using ComicStoreBL.Interfaces;
using ComicStoreBL.Models;
using ComicStoreDAL.Entities;
using ComicStoreDAL.Interfaces;
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
        public ComicBookService(IGenericRepository<ComicBook> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
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
