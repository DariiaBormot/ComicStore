using ComicStoreBL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComicStoreDAL.Interfaces;
using ComicStoreDAL.Repositories;


namespace ComicStoreBL.Services
{
    public abstract class GenericService<BLModel, DALModel> : IGenericService<BLModel>
       where BLModel : class
       where DALModel : class
    {
        private readonly IGenericRepository<DALModel> _repositry;
        public GenericService(IGenericRepository<DALModel> repository)
        {
            _repositry = repository;
        }

        public void Create(BLModel item)
        {
            var model = Map(item);
            _repositry.Create(model);
        }

        public void Delete(int id)
        {
            _repositry.Delete(id);
        }

        public IEnumerable<BLModel> GetAll()
        {
            var listEntity = _repositry.GetAll().ToList();
            return Map(listEntity);
        }

        public BLModel GetById(int id)
        {
            var model = _repositry.GetById(id);
            return Map(model);
        }
        public void Update(BLModel item)
        {
            var model = Map(item);
            _repositry.Update(model);
        }

        public abstract BLModel Map(DALModel entity);
        public abstract DALModel Map(BLModel blmodel);

        public abstract IEnumerable<BLModel> Map(IList<DALModel> entities);
        public abstract IEnumerable<DALModel> Map(IList<BLModel> models);

    }
}
