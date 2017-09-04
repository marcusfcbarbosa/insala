using Insala.Domain.Entities;
using Insala.Infra.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insala.Infra.DataContext
{
    public class Context : DbContext
    {
        public Context()
            : base("name=StandardConnectionString")
        {
            Database.SetInitializer<Context>(new ContextInitializer());
            Configuration.LazyLoadingEnabled = true;
            //resolver alguns problemas de serialização pelo navegador
            Configuration.ProxyCreationEnabled = false;
        }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new LogErrorMap());
            modelBuilder.Entity<User>().Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<LogError>().Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<LogError> LogErrors { get; set; }
    }
    public class ContextInitializer : CreateDatabaseIfNotExists<Context>
    {
        public ContextInitializer()
        {
        }

        protected override void Seed(Context context)
        {
            base.Seed(context);
        }
    }
}
