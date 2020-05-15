using AutoMapper;
using ComicStoreBL.Interfaces;
using ComicStoreBL.Models;
using ComicStoreDAL.Entities;
using ComicStoreDAL.Filters;
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
        private readonly IGenericRepository<OrderDetails> _repository;
        public OrderDetailsService(IGenericRepository<OrderDetails> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
            _repository = repository;
        }


        public IEnumerable<OrderDetailsBL> GetOrderDetailsByOrderId(int? id)
        {
            var ordersDetailsDAL = _repository.GetWhere(x => x.OrderId == id);

            var orderDetailsBL = _mapper.Map<IEnumerable<OrderDetailsBL>>(ordersDetailsDAL);

            return orderDetailsBL;
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
