using Insala.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insala.Infra.Mapping
{
    public class LogErrorMap : EntityTypeConfiguration<LogError>
    {

        public LogErrorMap() {
            ToTable("LogErrors");
            HasKey(x => x.Id);
            Property(x => x.EntityReference).HasMaxLength(20).IsRequired();
            Property(x => x.Error).IsRequired();
        }


    }
}
