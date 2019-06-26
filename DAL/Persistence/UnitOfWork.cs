using DAL.Core;
using DAL.Core.Repositories;
using DAL.Persistence.Repositories;
using System;
using System.Collections;

namespace DAL.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly My_DBContext _context;
        private Hashtable _repositories;

        public UnitOfWork(My_DBContext context)
        {
            _context = context;
       
        }

       

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
        public TRepository Repository<TEntity, TRepository>() where TEntity : class
          where TRepository : IRepository<TEntity>
        {
            if (_repositories == null)
                _repositories = new Hashtable();

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                object repositoryInstance;
                var repositoryType = typeof(TRepository);
                if (repositoryType.IsGenericType)
                {
                    repositoryInstance = Activator.CreateInstance(repositoryType
                        .MakeGenericType(typeof(TEntity)), _context);
                }
                else
                {
                    repositoryInstance = Activator.CreateInstance(repositoryType, _context);
                }
                _repositories.Add(type, repositoryInstance);
            }

            return (TRepository)_repositories[type];
        }
    }
}