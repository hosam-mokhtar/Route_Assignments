using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Layer.Models;

namespace Domain.Layer.Contracts
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();

        //public IGenericRepository<Product,int> ProductRepository { get;}                 XXXXXXXXXXX
        //public IGenericRepository<Department,int> ProductRepository { get;}              XXXXXXXXXXX

        public IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey>;
    }
}
