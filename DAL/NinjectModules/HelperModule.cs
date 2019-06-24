using DAL.Core;
using DAL.Persistence;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.NinjectModules
{
    public class HelperModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>();
            Bind<UnitOfWork>().ToSelf().InSingletonScope();
            Bind<My_DBContext>().ToSelf().InSingletonScope();
        }
    }
}
