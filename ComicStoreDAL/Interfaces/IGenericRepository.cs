﻿using ComicStoreDAL.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ComicStoreDAL.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        void Create(TEntity item);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity item);
        void Delete(int id);
        TEntity GetById(int id);
        TEntity CreateGetCreatedItem(TEntity item); 
        IEnumerable<TEntity> GetByFilter(IFilter<TEntity> filter);
        IEnumerable<TEntity> GetWhere(Expression<Func<TEntity, bool>> predicate);
        int Count(IFilter<TEntity> filter);
    }
}
