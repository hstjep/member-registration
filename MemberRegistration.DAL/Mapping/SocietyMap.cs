using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MemberRegistration.DAL.Mapping
{
    public class SocietyMap : EntityTypeConfiguration<Society>
    {
        public SocietyMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(60);

            this.Property(t => t.Acronym)
               .HasMaxLength(10);

            this.Property(t => t.Address)
                .HasMaxLength(40);

            this.Property(t => t.Place)
                .HasMaxLength(20);

            this.Property(t => t.PostalCode)
                .HasMaxLength(20);

            this.Property(t => t.Country)
                .HasMaxLength(20);

            this.Property(t => t.OIB)
                .HasMaxLength(11);

            this.Property(t => t.WebSite)
                .HasMaxLength(50);

            this.Property(t => t.IBAN)
                .HasMaxLength(70);

            this.Property(t => t.Bank)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Society");
            this.Property(t => t.Name).HasColumnName("Name").HasColumnType("NVarchar");
            this.Property(t => t.Acronym).HasColumnName("Acronym").HasColumnType("NVarchar");
            this.Property(t => t.Address).HasColumnName("Address").HasColumnType("NVarchar");
            this.Property(t => t.Place).HasColumnName("Place").HasColumnType("NVarchar");
            this.Property(t => t.PostalCode).HasColumnName("PostalCode").HasColumnType("Varchar");
            this.Property(t => t.Country).HasColumnName("Country").HasColumnType("NVarchar");
            this.Property(t => t.OIB).HasColumnName("OIB");
            this.Property(t => t.WebSite).HasColumnName("WebSite");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Logo).HasColumnName("Logo");
            this.Property(t => t.MimeTypeImage).HasColumnName("MimeTypeImage");
            this.Property(t => t.IBAN).HasColumnName("IBAN");
            this.Property(t => t.CashRegisterLocation).HasColumnName("CashRegisterLocation").HasColumnType("NVarchar");
            this.Property(t => t.Bank).HasColumnName("Bank").HasColumnType("NVarchar");
            this.Property(t => t.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
