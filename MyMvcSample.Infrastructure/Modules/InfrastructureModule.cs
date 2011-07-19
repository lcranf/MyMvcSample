using EFHooks;
using MyMvcSample.Infrastructure.Db;
using Ninject.Modules;

namespace MyMvcSample.Infrastructure.Modules
{
    public class InfrastructureModule : NinjectModule
    {
        public override void Load()
        {
            //bind EFHooks
            Bind<IHook>().To<AuditablePreInsertHook>().InTransientScope();
            Bind<IHook>().To<AuditablePreUpdateHook>().InTransientScope();
        }
    }
}
