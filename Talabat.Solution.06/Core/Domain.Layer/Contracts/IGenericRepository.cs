using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Layer.Models;

namespace Domain.Layer.Contracts
{
    public interface IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        #region Without Specifications

        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(TKey id);

        #endregion

        #region With Specifications

        Task<TEntity?> GetByIdAsync(ISpecifications<TEntity, TKey> specifications);
        Task<IEnumerable<TEntity>> GetAllAsync(ISpecifications<TEntity, TKey> specifications);
        Task<int> CountAsync(ISpecifications<TEntity, TKey> specifications);

        #endregion


        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
