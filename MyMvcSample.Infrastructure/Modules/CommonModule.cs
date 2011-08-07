using MyMvcSample.Common.Mvc.ModelBinders;
using MyMvcSample.Common.Repository;
using Ninject.Modules;

namespace MyMvcSample.Infrastructure.Modules
{
    public class CommonModule : NinjectModule
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            Bind(typeof(IRepository<>)).To(typeof(Repository<>)).InTransientScope();

            Bind<IFilteredModelBinder>().To<EntityModelBinder>().InTransientScope();
            Bind<SmartModelBinder>().ToSelf().InTransientScope();
        }
    }
}
