using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.DAL.Repositories.Interfaces
{
    public interface IGenericRepository<TEnitiy> where TEnitiy : BaseEntity
    {
        public int Add(TEnitiy enitiy);
        public IEnumerable<TEnitiy> GetAll(bool withTracking = false);
        public TEnitiy? GetById(int id);
        public int Update(TEnitiy enitiy);
        public int Delete(TEnitiy enitiy);
    }
}
