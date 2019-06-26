using DAL.Core.Repositories;
using System;

namespace DAL.Core
{
    public interface IUnitOfWork : IDisposable
    {
       
        int Complete();
        TRepository Repository<TEntity, TRepository>() where TEntity : class
         where TRepository : IRepository<TEntity>;
    }
}