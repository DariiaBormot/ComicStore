using ComicStoreBL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComicStoreDAL.Interfaces;
using ComicStoreDAL.Repositories;
using ComicStoreBL.Models;
using AutoMapper;
using ComicStoreDAL.Filters;

namespace ComicStoreBL.Services
{
    public abstract class GenericService<BLModel, DALModel> : IGenericService<BLModel>
       where BLModel : class
       where DALModel : class
    {
        private readonly IGenericRepository<DALModel> _repository;
        public GenericService(IGenericRepository<DALModel> repository)
        {
            _repository = repository;
        }

        public void Create(BLModel item)
        {
            var model = Map(item);
            _repository.Create(model);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public IEnumerable<BLModel> GetAll()
        {
            var listEntity = _repository.GetAll().ToList();
            return Map(listEntity);
        }

        public BLModel GetById(int id)
        {
            var model = _repository.GetById(id);
            return Map(model);
        }
        public void Update(BLModel item)
        {
            var model = Map(item);
            _repository.Update(model);
        }

        public BLModel CreateGetCreatedItem(BLModel item) 
        {
            var model = Map(item);
            var modelDAL = _repository.CreateGetCreatedItem(model);
            var modelToReturn = Map(modelDAL);
            return modelToReturn;
        }

        public abstract BLModel Map(DALModel entity);
        public abstract DALModel Map(BLModel blmodel);

        public abstract IEnumerable<BLModel> Map(IList<DALModel> entities);
        public abstract IEnumerable<DALModel> Map(IList<BLModel> models);

        
    }
}
