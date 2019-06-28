using BL.BussinesManagers.Interfaces;
using DAL.Core;
using DAL.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BL.BussinesManagers.Classes
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TRepository"></typeparam>
    public class BaseBussinesManager<TEntity, TRepository> : IBaseBussinesManager<TEntity> where TEntity : class
        where TRepository : IRepository<TEntity>
    {
        public BaseBussinesManager(IUnitOfWork _uow)
        {
            if (_uow == null)
            {
                throw new ArgumentNullException("no repository provided");
            }
            UnitOfWork = _uow;
            Repository = UnitOfWork.Repository<TEntity, TRepository>();

        }

        protected IRepository<TEntity> Repository { get; set; }
        protected IUnitOfWork UnitOfWork { get; set; }
        IUnitOfWork IBaseBussinesManager<TEntity>.UnitOfWork { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public TEntity Get(int id)
        {
            // Here we are working with a DbContext, not My_DBContext. So we don't have DbSets 
            // such as Courses or Authors, and we need to use the generic Set() method to access them.
            return Repository.Get(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            // Note that here I've repeated Context.Set<TEntity>() in every method and this is causing
            // too much noise. I could get a reference to the DbSet returned from this method in the 
            // constructor and store it in a private field like _entities. This way, the implementation
            // of our methods would be cleaner:
            // 
            // _entities.ToList();
            // _entities.Where();
            // _entities.SingleOrDefault();
            // 
            // I didn't change it because I wanted the code to look like the videos. But feel free to change
            // this on your own.
            return Repository.GetAll();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Repository.Find(predicate);
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return Repository.SingleOrDefault(predicate);
        }

        public void Add(TEntity entity)
        {
            Repository.Add(entity);
            UnitOfWork.Complete();
        }
        public void AddInMemory(TEntity entity)
        {
            Repository.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            Repository.AddRange(entities);
        }

        public void Remove(TEntity entity)
        {
            Repository.Remove(entity);
            UnitOfWork.Complete();

        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Repository.RemoveRange(entities);
        }
    }
}
