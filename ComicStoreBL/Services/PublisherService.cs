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
    public class PublisherService : GenericService<PublisherBL, Publisher>, IPublisherService
    {
        private readonly IMapper _mapper;
        public PublisherService(IGenericRepository<Publisher> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }
        public override PublisherBL Map(Publisher entity)
        {
            return _mapper.Map<PublisherBL>(entity);
        }

        public override Publisher Map(PublisherBL blmodel)
        {
            return _mapper.Map<Publisher>(blmodel);
        }

        public override IEnumerable<PublisherBL> Map(IList<Publisher> entities)
        {
            return _mapper.Map<IEnumerable<PublisherBL>>(entities);
        }

        public override IEnumerable<Publisher> Map(IList<PublisherBL> models)
        {
            return _mapper.Map<IEnumerable<Publisher>>(models);
        }
    }
}
