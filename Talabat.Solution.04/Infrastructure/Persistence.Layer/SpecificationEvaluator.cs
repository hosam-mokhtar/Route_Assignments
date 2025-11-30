using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Layer.Contracts;
using Domain.Layer.Models;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Layer
{
    internal static class SpecificationEvaluator
    {
        //Create Query
        //_storeDbContext.Set<TEntity>().Where(p => p.Id == id &&     ).InClude(p => p.ProductBrand).InClude(p => p.ProductType);

        public static IQueryable<TEntity> CreateQuery<TEntity, TKey> (IQueryable<TEntity> inputQuery, ISpecifications<TEntity, TKey> specifications) 
            where TEntity : BaseEntity<TKey> 
        {
            var query = inputQuery;

            if (specifications.Criteria is not null)
            {
                query = query.Where(specifications.Criteria);
            }

            #region Ordering

            if (specifications.OrderBy is not null)
            {
                query = query.OrderBy(specifications.OrderBy);
            }
            if (specifications.OrderByDescending is not null)
            {
                query = query.OrderByDescending(specifications.OrderByDescending);
            }

            #endregion

            #region Includes

            if (specifications.IncludesExpressions is not null && specifications.IncludesExpressions.Count > 0)
            {
                //foreach (var include in specifications.IncludesExpressions)
                //{
                //    query.Include(include);
                //}

                //OR Aggregate Function
                query = specifications.IncludesExpressions
                                      .Aggregate(query, (current, includesExpression) => current.Include(includesExpression));
            }

            #endregion

            #region Pagination

            if(specifications.IsPaginated)
            {
                query = query.Skip(specifications.Skip).Take(specifications.Take);
            }

            #endregion

            return query;
        }
    }
}
