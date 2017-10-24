using Nymity.Demo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nymity.Demo.Infra.Data.Configuration
{
    public class EmployeeConfiguration : EntityTypeConfiguration<Employee>
    {

        public EmployeeConfiguration()
        {
            ToTable("Employees");
            HasKey(x => x.EmployeeId);

            Property(x => x.EmployeeId).HasColumnName(@"EmployeeID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.LastName).HasColumnName(@"LastName").HasColumnType("nvarchar").IsRequired().HasMaxLength(20);
            Property(x => x.FirstName).HasColumnName(@"FirstName").HasColumnType("nvarchar").IsRequired().HasMaxLength(10);
            Property(x => x.Title).HasColumnName(@"Title").HasColumnType("nvarchar").IsOptional().HasMaxLength(30);
            Property(x => x.TitleOfCourtesy).HasColumnName(@"TitleOfCourtesy").HasColumnType("nvarchar").IsOptional().HasMaxLength(25);
            Property(x => x.BirthDate).HasColumnName(@"BirthDate").HasColumnType("datetime").IsOptional();
            Property(x => x.HireDate).HasColumnName(@"HireDate").HasColumnType("datetime").IsOptional();
            Property(x => x.Address).HasColumnName(@"Address").HasColumnType("nvarchar").IsOptional().HasMaxLength(60);
            Property(x => x.City).HasColumnName(@"City").HasColumnType("nvarchar").IsOptional().HasMaxLength(15);
            Property(x => x.Region).HasColumnName(@"Region").HasColumnType("nvarchar").IsOptional().HasMaxLength(15);
            Property(x => x.PostalCode).HasColumnName(@"PostalCode").HasColumnType("nvarchar").IsOptional().HasMaxLength(10);
            Property(x => x.Country).HasColumnName(@"Country").HasColumnType("nvarchar").IsOptional().HasMaxLength(15);
            Property(x => x.HomePhone).HasColumnName(@"HomePhone").HasColumnType("nvarchar").IsOptional().HasMaxLength(24);
            Property(x => x.Extension).HasColumnName(@"Extension").HasColumnType("nvarchar").IsOptional().HasMaxLength(4);
            Property(x => x.Photo).HasColumnName(@"Photo").HasColumnType("image").IsOptional().HasMaxLength(2147483647);
            Property(x => x.Notes).HasColumnName(@"Notes").HasColumnType("ntext").IsOptional().IsMaxLength();
            Property(x => x.ReportsTo).HasColumnName(@"ReportsTo").HasColumnType("int").IsOptional();
            Property(x => x.PhotoPath).HasColumnName(@"PhotoPath").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);

            // Foreign keys
            HasOptional(a => a.Employee_ReportsTo).WithMany(b => b.Employees).HasForeignKey(c => c.ReportsTo).WillCascadeOnDelete(false);
            HasMany(t => t.Territories).WithMany(t => t.Employees).Map(m =>
            {
                m.ToTable("EmployeeTerritories", "dbo");
                m.MapLeftKey("EmployeeID");
                m.MapRightKey("TerritoryID");
            });
        }
    }
}
