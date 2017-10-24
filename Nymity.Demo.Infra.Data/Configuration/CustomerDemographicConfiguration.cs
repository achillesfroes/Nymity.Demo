using Nymity.Demo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nymity.Demo.Infra.Data.Configuration
{
    public class CustomerDemographicConfiguration : EntityTypeConfiguration<CustomerDemographic>
    {
        public CustomerDemographicConfiguration()
        {
            ToTable("CustomerDemographics");
            HasKey(x => x.CustomerTypeId);

            Property(x => x.CustomerTypeId).HasColumnName(@"CustomerTypeID").HasColumnType("nchar").IsRequired().IsFixedLength().HasMaxLength(10).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.CustomerDesc).HasColumnName(@"CustomerDesc").HasColumnType("ntext").IsOptional().IsMaxLength();
        }
    }
}
