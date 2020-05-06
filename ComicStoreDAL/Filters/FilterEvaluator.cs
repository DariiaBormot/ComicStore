using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicStoreDAL.Filters
{
    public class FilterEvaluator<TEntity> where TEntity : class 
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, IFilter<TEntity> specification)
        {
            var query = inputQuery;

            if (specification.Criteria != null)
            {
                query = query.Where(specification.Criteria);
            }
            if (specification.OrderBy != null)
            {
                query = query.OrderBy(specification.OrderBy);
            }
            if (specification.OrderByDecending != null)
            {
                query = query.OrderByDescending(specification.OrderByDecending);
            }
            if (specification.IsPagingEnabled)
            {
                query = query.Skip(specification.Skip).Take(specification.Take);
            }

            query = specification.Includes.Aggregate(query, (current, include) => current.Include(include));

            return query;
        }
    }
}
