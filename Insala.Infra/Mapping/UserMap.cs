using Insala.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insala.Infra.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("Users");
            HasKey(x=>x.Id);
            Property(x => x.Email).HasMaxLength(60).IsRequired();
            Property(x => x.Type).IsRequired();
        }

    }
}
