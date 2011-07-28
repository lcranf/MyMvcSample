using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using EFHooks;
using MyMvcSample.Common.Extensions;
using MyMvcSample.Domain.Entities;
using Ninject;

namespace MyMvcSample.Domain.Db
{
    public class MyMvcSampleContext : HookedDbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<MyMvcSample.Models.MyMvcSampleContext>());

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderLineItem> OrderLineItems { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<OrderStatus> OrderStatuses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }

        [Inject]
        public void AddHooks(IEnumerable<IHook> hooks)
        {
            if (hooks.IsNullOrEmpty()) return;

            var postActions = hooks.OfType<IPostActionHook>();
            
            foreach (var postAction in postActions)
            {
                RegisterHook(postAction);
            }

            var preActions = hooks.OfType<IPreActionHook>();

            foreach (var preAction in preActions)
            {
                RegisterHook(preAction);
            }

            //if using hooks, bypass validation just in case a hook
            //is providing a value that the validation is failing on.
            //In either case, the database will be the true validator
            Configuration.ValidateOnSaveEnabled = false;

        }
    }
}