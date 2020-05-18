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
    public class OrderService : GenericService<OrderBL, Order>, IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Order> _repository;

        public OrderService(IGenericRepository<Order> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
            _repository = repository;
        }


        public IEnumerable<OrderBL> GetListByFilter(OrderFilterModelBL filter)
        {
            var filterDAL = _mapper.Map<OrderFilterModel>(filter);

            var filterImp = new OrderFilter(filterDAL);

            var ordersDal = _repository.GetByFilter(filterImp);

            var ordersBL = _mapper.Map<IEnumerable<OrderBL>>(ordersDal);

            return ordersBL;
        }

        public int CountFilteredItems(OrderFilterModelBL filter)
        {
            var filterDAL = _mapper.Map<OrderFilterModel>(filter);

            var coutFilter = new OrderFilter(filterDAL);

            var count = _repository.Count(coutFilter);

            return count;
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
