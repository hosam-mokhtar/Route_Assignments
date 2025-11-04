using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Assignment.DAL.Repositories.Classes
{
    public class GenericRepository<TEntity>(ApplicationDbContext _context) : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        #region 5 CRUD Operations 
        public TEntity? GetById(int id)
                           => _context.Set<TEntity>().Find(id);

        public IEnumerable<TEntity> GetAll(bool withTracking = false)
        {
            if (withTracking)
                return _context.Set<TEntity>().Where(entity => entity.IsDeleted == false).ToList();
              //if you need all employees even all deleted
              //return _context.Set<TEntity>().ToList();
            else
                return _context.Set<TEntity>().Where(entity => entity.IsDeleted == false).AsNoTracking().ToList();
              //if you need all employees even all deleted
              //return _context.Set<TEntity>().AsNoTracking().ToList();
        }

        public int Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            return _context.SaveChanges();
        }

        public int Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            return _context.SaveChanges();

        }
        public int Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            return _context.SaveChanges();
        }

        #endregion
    }
}
