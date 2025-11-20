using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.DAL.Repositories.Interfaces
{
    public interface IGenericRepository<TEnitiy> where TEnitiy : BaseEntity
    {
        public IEnumerable<TEnitiy> GetAll(bool withTracking = false);
        public IEnumerable<TResult> GetAll<TResult>(Expression<Func<TEnitiy,TResult>> selector);
        public IEnumerable<TEnitiy> GetAll(Expression<Func<TEnitiy,bool>> predicate);
        public TEnitiy? GetById(int id);
        public /*int*/ void Add(TEnitiy enitiy);
        public /*int*/ void Update(TEnitiy enitiy);
        public /*int*/ void Delete(TEnitiy enitiy);

        //IEnumerable<TEnitiy> GetIEnumerable();
        //IQueryable<TEnitiy> GetIQueryable();
    }
}
