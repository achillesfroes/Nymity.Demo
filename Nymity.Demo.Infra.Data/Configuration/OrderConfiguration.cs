using Nymity.Demo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nymity.Demo.Infra.Data.Configuration
{
    public class OrderConfiguration : EntityTypeConfiguration<Order>
    {
        public OrderConfiguration()
        {
            ToTable("Orders");
            HasKey(x => x.OrderId);

            Property(x => x.OrderId).HasColumnName(@"OrderID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.CustomerId).HasColumnName(@"CustomerID").HasColumnType("nchar").IsOptional().IsFixedLength().HasMaxLength(5);
            Property(x => x.EmployeeId).HasColumnName(@"EmployeeID").HasColumnType("int").IsOptional();
            Property(x => x.OrderDate).HasColumnName(@"OrderDate").HasColumnType("datetime").IsOptional();
            Property(x => x.RequiredDate).HasColumnName(@"RequiredDate").HasColumnType("datetime").IsOptional();
            Property(x => x.ShippedDate).HasColumnName(@"ShippedDate").HasColumnType("datetime").IsOptional();
            Property(x => x.ShipVia).HasColumnName(@"ShipVia").HasColumnType("int").IsOptional();
            Property(x => x.Freight).HasColumnName(@"Freight").HasColumnType("money").IsOptional().HasPrecision(19, 4);
            Property(x => x.ShipName).HasColumnName(@"ShipName").HasColumnType("nvarchar").IsOptional().HasMaxLength(40);
            Property(x => x.ShipAddress).HasColumnName(@"ShipAddress").HasColumnType("nvarchar").IsOptional().HasMaxLength(60);
            Property(x => x.ShipCity).HasColumnName(@"ShipCity").HasColumnType("nvarchar").IsOptional().HasMaxLength(15);
            Property(x => x.ShipRegion).HasColumnName(@"ShipRegion").HasColumnType("nvarchar").IsOptional().HasMaxLength(15);
            Property(x => x.ShipPostalCode).HasColumnName(@"ShipPostalCode").HasColumnType("nvarchar").IsOptional().HasMaxLength(10);
            Property(x => x.ShipCountry).HasColumnName(@"ShipCountry").HasColumnType("nvarchar").IsOptional().HasMaxLength(15);

            HasOptional(a => a.Customer).WithMany(b => b.Orders).HasForeignKey(c => c.CustomerId).WillCascadeOnDelete(false);
            HasOptional(a => a.Employee).WithMany(b => b.Orders).HasForeignKey(c => c.EmployeeId).WillCascadeOnDelete(false);
            HasOptional(a => a.Shipper).WithMany(b => b.Orders).HasForeignKey(c => c.ShipVia).WillCascadeOnDelete(false);
        }
    }
}
