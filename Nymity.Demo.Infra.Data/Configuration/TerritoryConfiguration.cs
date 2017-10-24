using Nymity.Demo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nymity.Demo.Infra.Data.Configuration
{
    public class TerritoryConfiguration : EntityTypeConfiguration<Territory>
    {

        public TerritoryConfiguration()
        {
            ToTable("Territories");
            HasKey(x => x.TerritoryId);

            Property(x => x.TerritoryId).HasColumnName(@"TerritoryID").HasColumnType("nvarchar").IsRequired().HasMaxLength(20).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.TerritoryDescription).HasColumnName(@"TerritoryDescription").HasColumnType("nchar").IsRequired().IsFixedLength().HasMaxLength(50);
            Property(x => x.RegionId).HasColumnName(@"RegionID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.Region).WithMany(b => b.Territories).HasForeignKey(c => c.RegionId).WillCascadeOnDelete(false); // FK_Territories_Region
        }
    }
}
