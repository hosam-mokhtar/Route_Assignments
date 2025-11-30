using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Layer.Models;

namespace Domain.Layer.Contracts
{
    public interface ISpecifications<TEntity, Tkey> where TEntity :  BaseEntity<Tkey>
    {
        public Expression<Func<TEntity, bool>>? Criteria { get; }
        public List<Expression<Func<TEntity, object>>> IncludesExpressions { get; }

        public Expression<Func<TEntity, object>> OrderBy { get; }
        public Expression<Func<TEntity, object>> OrderByDescending { get; }


        public int Skip { get; }
        public int Take { get; }
        public bool IsPaginated { get; }

    }
}
