using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CommonServiceLocator.NinjectAdapter;
using Microsoft.Practices.ServiceLocation;
using MyMvcSample.Domain.Db;
using Ninject;
using Ninject.Extensions.Conventions;

namespace MyMvcSample.Infrastructure.Ioc
{
    public class IocRegistrar
    {
        public static void Register(IKernel kernel)
        {
            var scanner = new AssemblyScanner();

            var assemblies = GetAssembliesMatching("MyMvcSample");
            
            scanner.From(assemblies);
            scanner.BindWithDefaultConventions();
            scanner.AutoLoadModules();
            scanner.InTransientScope();

            //get exclusion list
            var exclusionList = GetExclusionList();

            exclusionList.ToList().ForEach(scanner.Excluding);
            
            //start scan
            kernel.Scan(scanner);

            var locator = new NinjectServiceLocator(kernel);

            ServiceLocator.SetLocatorProvider(() => locator);


        }

        private static IEnumerable<Assembly> GetAssembliesMatching(string pattern)
        {
            return from ass in AppDomain.CurrentDomain.GetAssemblies()
                   where ass.FullName.StartsWith(pattern)
                   select ass;
        }

        /// <summary>
        /// Add types to exclude from default convention binder
        /// </summary>
        /// <returns></returns>
        private static IEnumerable<Type> GetExclusionList()
        {
            return new List<Type> { typeof(DbContextRegistry) };
        }
    }
}