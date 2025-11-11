using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Layer.Contracts;
using Domain.Layer.Models;
using Persistence.Layer.Data;

namespace Persistence.Layer.Repositories
{
    public class UnitOfWork(StoreDbContext _storeDbContext) : IUnitOfWork
    {
        private readonly Dictionary<string, Object> _repositories = [];

        public IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {
            //Get Type Name
            var typeName = typeof(TEntity).Name;

            //Dictionary<string, Object> => < Product , Object from GenericRepository<Product> >


            //if (_repositories.ContainsKey(typeName))
            //    //return _repositories[typeName] as IGenericRepository<TEntity, TKey>;
            //    //or
            //    return (IGenericRepository<TEntity, TKey>)_repositories[typeName];

            if (_repositories.TryGetValue(typeName, out object? value))
                return (IGenericRepository<TEntity, TKey>)value;
            else
            {
                //Creating Object 
                var repo = new GenericRepositories<TEntity, TKey>(_storeDbContext);
                //_repositories[typeName] = repo;                                      //Store Repo in Dictionary
                _repositories.Add(typeName, repo);
                return repo;
            }

        }

        public async Task<int> SaveChangesAsync() => await _storeDbContext.SaveChangesAsync();
    }
}
