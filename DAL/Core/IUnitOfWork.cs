using DAL.Core.Repositories;
using System;

namespace DAL.Core
{
    public interface IUnitOfWork : IDisposable
    {
       
        int Complete();
    }
}