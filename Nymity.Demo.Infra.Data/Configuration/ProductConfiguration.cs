using Nymity.Demo.Domain.Models;

namespace Nymity.Demo.Infra.Data.Configuration
{
    public class ProductConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            ToTable("Products");
            HasKey(x => x.ProductId);

            Property(x => x.ProductId).HasColumnName(@"ProductID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.ProductName).HasColumnName(@"ProductName").HasColumnType("nvarchar").IsRequired().HasMaxLength(40);
            Property(x => x.SupplierId).HasColumnName(@"SupplierID").HasColumnType("int").IsOptional();
            Property(x => x.CategoryId).HasColumnName(@"CategoryID").HasColumnType("int").IsOptional();
            Property(x => x.QuantityPerUnit).HasColumnName(@"QuantityPerUnit").HasColumnType("nvarchar").IsOptional().HasMaxLength(20);
            Property(x => x.UnitPrice).HasColumnName(@"UnitPrice").HasColumnType("money").IsOptional().HasPrecision(19, 4);
            Property(x => x.UnitsInStock).HasColumnName(@"UnitsInStock").HasColumnType("smallint").IsOptional();
            Property(x => x.UnitsOnOrder).HasColumnName(@"UnitsOnOrder").HasColumnType("smallint").IsOptional();
            Property(x => x.ReorderLevel).HasColumnName(@"ReorderLevel").HasColumnType("smallint").IsOptional();
            Property(x => x.Discontinued).HasColumnName(@"Discontinued").HasColumnType("bit").IsRequired();

            HasOptional(a => a.Category).WithMany(b => b.Products).HasForeignKey(c => c.CategoryId).WillCascadeOnDelete(false);
            HasOptional(a => a.Supplier).WithMany(b => b.Products).HasForeignKey(c => c.SupplierId).WillCascadeOnDelete(false);
        }
    }
}
