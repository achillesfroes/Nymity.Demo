using Nymity.Demo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nymity.Demo.Infra.Data.Configuration
{
    public class CustomerConfiguration : EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration()
        {
            ToTable("Customers");
            HasKey(x => x.CustomerId);

            Property(x => x.CustomerId).HasColumnName(@"CustomerID").HasColumnType("nchar").IsRequired().IsFixedLength().HasMaxLength(5).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.CompanyName).HasColumnName(@"CompanyName").HasColumnType("nvarchar").IsRequired().HasMaxLength(40);
            Property(x => x.ContactName).HasColumnName(@"ContactName").HasColumnType("nvarchar").IsOptional().HasMaxLength(30);
            Property(x => x.ContactTitle).HasColumnName(@"ContactTitle").HasColumnType("nvarchar").IsOptional().HasMaxLength(30);
            Property(x => x.Address).HasColumnName(@"Address").HasColumnType("nvarchar").IsOptional().HasMaxLength(60);
            Property(x => x.City).HasColumnName(@"City").HasColumnType("nvarchar").IsOptional().HasMaxLength(15);
            Property(x => x.Region).HasColumnName(@"Region").HasColumnType("nvarchar").IsOptional().HasMaxLength(15);
            Property(x => x.PostalCode).HasColumnName(@"PostalCode").HasColumnType("nvarchar").IsOptional().HasMaxLength(10);
            Property(x => x.Country).HasColumnName(@"Country").HasColumnType("nvarchar").IsOptional().HasMaxLength(15);
            Property(x => x.Phone).HasColumnName(@"Phone").HasColumnType("nvarchar").IsOptional().HasMaxLength(24);
            Property(x => x.Fax).HasColumnName(@"Fax").HasColumnType("nvarchar").IsOptional().HasMaxLength(24);
            HasMany(t => t.CustomerDemographics).WithMany(t => t.Customers).Map(m =>
            {
                m.ToTable("CustomerCustomerDemo", "dbo");
                m.MapLeftKey("CustomerID");
                m.MapRightKey("CustomerTypeID");
            });
        }
    }
}
