using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Layer.Contracts;
using Domain.Layer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Persistence.Layer.Data;

namespace Persistence.Layer.Repositories
{
    public class GenericRepositories<TEntity, TKey>(StoreDbContext _storeDbContext) : IGenericRepository<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
    {

        #region Without Specifications

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        => await _storeDbContext.Set<TEntity>().ToListAsync();

        public async Task<TEntity?> GetByIdAsync(TKey id)
                        => await _storeDbContext.Set<TEntity>().FindAsync(id);

        #endregion

        #region With Specifications

        public async Task<IEnumerable<TEntity>> GetAllAsync(ISpecifications<TEntity, TKey> specifications)
        {
            //var baseQuery = _storeDbContext.Set<TEntity>();

            //if (specifications is not null)
            //{
            //    var criteria = specifications.Criteria;
            //    baseQuery = baseQuery.Where(criteria);
            //}
            //else if ()
            //{
            //}

            return await SpecificationEvaluator.CreateQuery(_storeDbContext.Set<TEntity>(), specifications).ToListAsync();

        }
        public async Task<TEntity?> GetByIdAsync(ISpecifications<TEntity, TKey> specifications)
        {
            //var baseQuery = _storeDbContext.Set<TEntity>();

            //if (specifications is not null)
            //{
            //    var criteria = specifications.Criteria;
            //    baseQuery = baseQuery.Where(criteria);
            //}
            //else if ()
            //{
            //}

            return await SpecificationEvaluator.CreateQuery(_storeDbContext.Set<TEntity>(), specifications).FirstOrDefaultAsync();
        }

        public async Task<int> CountAsync(ISpecifications<TEntity, TKey> specifications)
        {
            return await SpecificationEvaluator.CreateQuery(_storeDbContext.Set<TEntity>(), specifications).CountAsync(); ;
        }

        #endregion

        public async Task AddAsync(TEntity entity)
                      //=>  await _storeDbContext.AddAsync(entity);
                        =>  await _storeDbContext.Set<TEntity>().AddAsync(entity);            //Readability
       
        public void Update(TEntity entity)
                      //=> _storeDbContext.Update(entity);
                        => _storeDbContext.Set<TEntity>().Update(entity);                     //Readability

        public void Delete(TEntity entity)
                      //=> _storeDbContext.Remove(entity);
                        => _storeDbContext.Set<TEntity>().Remove(entity);                     //Readability

    }
}
