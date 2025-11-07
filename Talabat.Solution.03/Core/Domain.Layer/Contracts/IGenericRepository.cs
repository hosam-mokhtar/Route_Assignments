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
       Task<IEnumerable<TEntity>> GetAllAsync();
       Task<TEntity?> GetById(TKey id);
       Task AddAsync(TEntity entity);
       void Update(TEntity entity);
       void Delete(TEntity entity);

    }
}
