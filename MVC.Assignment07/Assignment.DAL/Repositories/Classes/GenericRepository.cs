using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            //if (withTracking)
            //return _context.Set<TEntity>().Where(entity => entity.IsDeleted == false).ToList();
            //if you need all employees even all deleted
            //return _context.Set<TEntity>().ToList();
            //else
            //return _context.Set<TEntity>().Where(entity => entity.IsDeleted == false).AsNoTracking().ToList();
            //if you need all employees even all deleted
            //return _context.Set<TEntity>().AsNoTracking().ToList();
             
            if (withTracking)
                return _context.Set<TEntity>().ToList();
            else
                return _context.Set<TEntity>().AsNoTracking().ToList();
        }

        public IEnumerable<TResult> GetAll<TResult>(System.Linq.Expressions.Expression<Func<TEntity, TResult>> selector)
        {
            return _context.Set<TEntity>()
                           .Where(entity => entity.IsDeleted == false)
                           .Select(selector).ToList();
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>()
                           .Where(predicate)
                           .ToList();
        }                  

        public /*int*/ void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            //return _context.SaveChanges();


            //Add In Order Table
            //Add In Order Items Table
            //Update Stock In Stores
        }

        public /*int*/ void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            //return _context.SaveChanges();

        }
        public /*int*/ void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            //return _context.SaveChanges();
        }

        #endregion

        //public IEnumerable<TEntity> GetIEnumerable()
        //{
        //    return _context.Set<TEntity>();
        //}

        //public IQueryable<TEntity> GetIQueryable()
        //{
        //    return _context.Set<TEntity>();
        //}

    }
}
