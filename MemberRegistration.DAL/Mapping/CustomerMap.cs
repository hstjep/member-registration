using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MemberRegistration.DAL.Mapping
{
    public class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.FirstName)
                .HasMaxLength(60);

            this.Property(t => t.LastName)
                .HasMaxLength(60);

            this.Property(t => t.OIB)
                .HasMaxLength(11);

            this.Property(t => t.Address)
                .HasMaxLength(100);

            this.Property(t => t.Place)
                .HasMaxLength(60);

            this.Property(t => t.PostalCode)
                .HasMaxLength(25);

            this.Property(t => t.Country)
              .HasMaxLength(50);

            this.Property(t => t.PdvId)
                .HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("Customer");
            this.Property(t => t.FirstName).HasColumnName("FirstName").HasColumnType("NVarchar");
            this.Property(t => t.LastName).HasColumnName("LastName").HasColumnType("NVarchar");
            this.Property(t => t.OIB).HasColumnName("OIB");
            this.Property(t => t.Address).HasColumnName("Address").HasColumnType("NVarchar");
            this.Property(t => t.Place).HasColumnName("Place").HasColumnType("NVarchar");
            this.Property(t => t.Country).HasColumnName("Country").HasColumnType("NVarchar");
            this.Property(t => t.PdvId).HasColumnName("PdvId").HasColumnType("Varchar");
            this.Property(t => t.IsMember).HasColumnName("IsMember");
            this.Property(t => t.PostalCode).HasColumnName("PostalCode").HasColumnType("Varchar");
        }
    }
}
