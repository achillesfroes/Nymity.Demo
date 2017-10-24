using Nymity.Demo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nymity.Demo.Infra.Data.Configuration
{
    public class OrderDetailConfiguration : EntityTypeConfiguration<OrderDetail>
    {

        public OrderDetailConfiguration()
        {
            ToTable("OrderDetails");
            HasKey(x => new { x.OrderId, x.ProductId });

            Property(x => x.OrderId).HasColumnName(@"OrderID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.ProductId).HasColumnName(@"ProductID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.UnitPrice).HasColumnName(@"UnitPrice").HasColumnType("money").IsRequired().HasPrecision(19, 4);
            Property(x => x.Quantity).HasColumnName(@"Quantity").HasColumnType("smallint").IsRequired();
            Property(x => x.Discount).HasColumnName(@"Discount").HasColumnType("real").IsRequired();

            HasRequired(a => a.Order).WithMany(b => b.OrderDetails).HasForeignKey(c => c.OrderId).WillCascadeOnDelete(false);
            HasRequired(a => a.Product).WithMany(b => b.OrderDetails).HasForeignKey(c => c.ProductId).WillCascadeOnDelete(false);
        }
    }
}
