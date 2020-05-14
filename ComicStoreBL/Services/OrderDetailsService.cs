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
    public class OrderDetailsService : GenericService<OrderDetailsBL, OrderDetails>, IOrderDetailsService
    {
        private readonly IMapper _mapper;
        public OrderDetailsService(IGenericRepository<OrderDetails> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }
        public override OrderDetailsBL Map(OrderDetails entity)
        {
            return _mapper.Map<OrderDetailsBL>(entity);
        }

        public override OrderDetails Map(OrderDetailsBL blmodel)
        {
            return _mapper.Map<OrderDetails>(blmodel);
        }

        public override IEnumerable<OrderDetailsBL> Map(IList<OrderDetails> entities)
        {
            return _mapper.Map<IEnumerable<OrderDetailsBL>>(entities);
        }

        public override IEnumerable<OrderDetails> Map(IList<OrderDetailsBL> models)
        {
            return _mapper.Map<IEnumerable<OrderDetails>>(models);
        }
    }
}
