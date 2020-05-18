using ComicStoreBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicStoreBL.Interfaces
{
    public interface IGenericService<Model> where Model : class
    {
        void Create(Model item);
        IEnumerable<Model> GetAll();
        void Update(Model item);
        void Delete(int id);
        Model GetById(int id);
        Model CreateGetCreatedItem(Model item);

    }
}
