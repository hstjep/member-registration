using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MemberRegistration.DAL.Mapping
{
    public class InvoiceItemMap : EntityTypeConfiguration<InvoiceItem>
    {
        public InvoiceItemMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("InvoiceItem");
            this.Property(t => t.InvoiceId).HasColumnName("InvoiceId");
            this.Property(t => t.ProductId).HasColumnName("ProductId");
            this.Property(t => t.Year).HasColumnName("Year");
            this.Property(t => t.MemberId).HasColumnName("MemberId");
            this.Property(t => t.CurrencyUnit).HasColumnName("CurrencyUnit");
            this.Property(t => t.Quantity).HasColumnName("Quantity");
            this.Property(t => t.Value).HasColumnName("Amount").HasColumnType("Decimal").HasPrecision(18, 2);
            this.Property(t => t.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Relationships
            this.HasRequired(t => t.Member)
                .WithMany(t => t.InvoiceItems)
                .HasForeignKey(d => d.MemberId)
                .WillCascadeOnDelete(true);
            this.HasRequired(t => t.Product)
                .WithMany(t => t.InvoiceItems)
                .HasForeignKey(d => d.ProductId)
                .WillCascadeOnDelete(true);
            this.HasRequired(t => t.Invoice)
                .WithMany(t => t.InvoiceItems)
                .HasForeignKey(d => d.InvoiceId)
                .WillCascadeOnDelete(true);
        }
    }
}
