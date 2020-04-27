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
    public class OrderService : GenericService<OrderBL, Order>, IOrderService
    {
        private readonly IMapper _mapper;
        public OrderService(IGenericRepository<Order> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }
        public override OrderBL Map(Order entity)
        {
            return _mapper.Map<OrderBL>(entity);
        }

        public override Order Map(OrderBL blmodel)
        {
            return _mapper.Map<Order>(blmodel);
        }

        public override IEnumerable<OrderBL> Map(IList<Order> entities)
        {
            return _mapper.Map<IEnumerable<OrderBL>>(entities);
        }

        public override IEnumerable<Order> Map(IList<OrderBL> models)
        {
            return _mapper.Map<IEnumerable<Order>>(models);
        }
    }
}
