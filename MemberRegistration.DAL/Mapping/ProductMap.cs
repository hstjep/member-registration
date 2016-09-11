using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MemberRegistration.DAL.Mapping
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("Product");
            this.Property(t => t.Name).HasColumnName("Name").HasColumnType("NVarchar");
            this.Property(t => t.MeasuringUnit).HasColumnName("MeasuringUnit");
            this.Property(t => t.Price).HasColumnName("Price").HasColumnType("Decimal").HasPrecision(18, 2);
            this.Property(t => t.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
