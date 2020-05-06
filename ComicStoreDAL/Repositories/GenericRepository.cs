using ComicStoreDAL.Interfaces;
using ComicStoreDAL.Filters;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicStoreDAL.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _context;
        public readonly DbSet<TEntity> dbSet;

        public GenericRepository()
        {
            _context = new ComicStoreContext();
            dbSet = _context.Set<TEntity>();
        }
        public void Create(TEntity item)
        {
            dbSet.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entityToDelete = dbSet.Find(id);

            if (entityToDelete != null)
            {
                dbSet.Remove(entityToDelete);
            }

            _context.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return dbSet.AsNoTracking().ToList();
        }

        public TEntity GetById(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public void Update(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public TEntity GetEntityByFilter(IFilter<TEntity> specification)
        {
            return ApplyFilters(specification).FirstOrDefault();
        }

        public IEnumerable<TEntity> GetListByFilter(IFilter<TEntity> specification)
        {
            return ApplyFilters(specification).ToList();
        }

        private IQueryable<TEntity> ApplyFilters(IFilter<TEntity> specification)
        {
            return FilterEvaluator<TEntity>.GetQuery(_context.Set<TEntity>().AsQueryable(), specification);
        }

    }
}
