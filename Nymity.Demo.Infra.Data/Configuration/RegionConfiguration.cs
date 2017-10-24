using Nymity.Demo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nymity.Demo.Infra.Data.Configuration
{
    public class RegionConfiguration : EntityTypeConfiguration<Region>
    {

        public RegionConfiguration()
        {
            ToTable("Region");
            HasKey(x => x.RegionId);

            Property(x => x.RegionId).HasColumnName(@"RegionID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.RegionDescription).HasColumnName(@"RegionDescription").HasColumnType("nchar").IsRequired().IsFixedLength().HasMaxLength(50);
        }
    }
}
