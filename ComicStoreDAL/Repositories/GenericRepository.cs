using ComicStoreDAL.Interfaces;
using ComicStoreDAL.Filters;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace ComicStoreDAL.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly ComicStoreContext _context;
        private readonly DbSet<TEntity> dbSet;

        public GenericRepository(ComicStoreContext context)
        {
            _context = context;
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
            return dbSet.ToList();
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

        public TEntity CreateGetCreatedItem(TEntity item)
        {
            dbSet.Add(item);
            _context.SaveChanges();
            return item;
        }

        public IEnumerable<TEntity> GetWhere(Expression<Func<TEntity, bool>> predicate)
        {
            return dbSet.Where(predicate).ToList();
        }

        public IEnumerable<TEntity> GetByFilter(IFilter<TEntity> expression)
        {
            return ApplyFilters(expression).ToList();
        }

        public int Count(IFilter<TEntity> filter)
        {
            return ApplyFilters(filter).Count();
        }

        private IQueryable<TEntity> ApplyFilters(IFilter<TEntity> expression)
        {
            return FilterEvaluator<TEntity>.GetQuery(_context.Set<TEntity>().AsQueryable(), expression);
        }

    }
}
