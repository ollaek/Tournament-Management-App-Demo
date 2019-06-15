using DAL.Core;
using DAL.Core.Repositories;
using DAL.Persistence.Repositories;

namespace DAL.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly My_DBContext _context;

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
    }
}