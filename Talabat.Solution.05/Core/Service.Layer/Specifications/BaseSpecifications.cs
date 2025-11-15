using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Layer.Contracts;
using Domain.Layer.Models;

namespace Service.Layer.Specifications
{
    public abstract class BaseSpecifications<TEntity, TKey> : ISpecifications<TEntity, TKey> 
                                                     where TEntity : BaseEntity<TKey>
    {

        public Expression<Func<TEntity, bool>>? Criteria { get; private set; }
        public BaseSpecifications(Expression<Func<TEntity, bool>>? criteria)
        {
            Criteria = criteria;
        }


        #region Includes
        public List<Expression<Func<TEntity, object>>> IncludesExpressions { get; } = [];

        protected void AddInclude(Expression<Func<TEntity, object>> includesExpression)
        {
            IncludesExpressions.Add(includesExpression);
        } 
        #endregion

        #region Ordering

        public Expression<Func<TEntity, object>> OrderBy { get; private set; }

        public Expression<Func<TEntity, object>> OrderByDescending { get; private set; }

        protected void AddOrderBy(Expression<Func<TEntity, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }

        protected void AddOrderByDescending(Expression<Func<TEntity, object>> orderByDescExpression)
        {
            OrderByDescending = orderByDescExpression;
        }

        #endregion

        #region Pagination

        public int Skip { get; set; }
        public int Take { get; set; }
        public bool IsPaginated { get; set; }

        protected void ApplyPagination(int pageSize, int pageIndex)
        {
            IsPaginated = true;
            Take = pageSize;   //No of Products per Page
            Skip = (pageIndex - 1) * pageSize;
        }

        #endregion
    }
}
