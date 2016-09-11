using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MemberRegistration.DAL.Mapping
{
    public class InvoiceMap : EntityTypeConfiguration<Invoice>
    {
        public InvoiceMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.PaymentMethod)
                .HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("Invoice");
            this.Property(t => t.SocietyId).HasColumnName("SocietyId");
            this.Property(t => t.CustomerId).HasColumnName("CustomerId");
            this.Property(t => t.Number).HasColumnName("Number");
            this.Property(t => t.PaymentDate).HasColumnName("PaymentDate");
            this.Property(t => t.MaturityDate).HasColumnName("MaturityDate");
            this.Property(t => t.PaymentMethod).HasColumnName("PaymentMethod").HasColumnType("NVarchar");
            this.Property(t => t.InvoiceIssuerId).HasColumnName("InvoiceIssuerId");
            this.Property(t => t.ResponsiblePersonId).HasColumnName("ResponsiblePersonId");
            this.Property(t => t.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Relationships
            this.HasRequired(t => t.InvoiceIssuer)
                 .WithMany(t => t.Invoices)
                 .HasForeignKey(d => d.InvoiceIssuerId)
                 .WillCascadeOnDelete(true);
            this.HasRequired(t => t.Customer)
                .WithMany(t => t.Invoices)
                .HasForeignKey(d => d.CustomerId)
                .WillCascadeOnDelete(true);
            this.HasRequired(t => t.ResponsiblePerson)
                .WithMany(t => t.Invoices)
                .HasForeignKey(d => d.ResponsiblePersonId)
                .WillCascadeOnDelete(true);
            this.HasRequired(t => t.Society)
                .WithMany(t => t.Invoices)
                .HasForeignKey(d => d.SocietyId)
                .WillCascadeOnDelete(true);
        }
    }
}
