using AutoMapper;
using MyMvcSample.Mappings;
using Ninject.Modules;

namespace MyMvcSample.Infrastructure.Modules
{
    public class WebModule : NinjectModule
    {
        public override void Load()
        {
            Mapper.Initialize(map =>
                                  {
                                      map.ConstructServicesUsing(Kernel.GetService);
                                      map.AddProfile<MyMvcSampleProfile>();
                                  });
        }
    }
}