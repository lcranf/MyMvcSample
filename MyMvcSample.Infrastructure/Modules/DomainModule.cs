using System.Data.Entity;
using MyMvcSample.Common.Db;
using MyMvcSample.Domain.Db;
using Ninject.Modules;

namespace MyMvcSample.Infrastructure.Modules
{
    public class DomainModule : NinjectModule
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            Bind<DbContext>().To<MyMvcSampleContext>().InTransientScope();
            Bind<IDbContextRegistry>().To<DbContextRegistry>().InRequestScope();
        }
    }
}
