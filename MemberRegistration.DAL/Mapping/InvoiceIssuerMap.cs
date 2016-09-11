using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MemberRegistration.DAL.Mapping
{
    public class InvoiceIssuerMap : EntityTypeConfiguration<InvoiceIssuer>
    {
        public InvoiceIssuerMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.FullName)
                .HasMaxLength(35);

            this.Property(t => t.OperatorLabel)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("InvoiceIssuer");
            this.Property(t => t.FullName).HasColumnName("FullName").HasColumnType("NVarchar");
            this.Property(t => t.OperatorLabel).HasColumnName("OperatorLable").HasColumnType("Varchar");
            this.Property(t => t.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
