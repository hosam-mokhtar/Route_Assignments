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
        public int Add(TEnitiy enitiy);
        public IEnumerable<TEnitiy> GetAll(bool withTracking = false);
        public IEnumerable<TResult> GetAll<TResult>(Expression<Func<TEnitiy,TResult>> selector);
        public TEnitiy? GetById(int id);
        public int Update(TEnitiy enitiy);
        public int Delete(TEnitiy enitiy);

        //IEnumerable<TEnitiy> GetIEnumerable();
        //IQueryable<TEnitiy> GetIQueryable();
    }
}
