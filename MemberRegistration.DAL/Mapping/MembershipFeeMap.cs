using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MemberRegistration.DAL.Mapping
{
    public class MembershipFeeMap : EntityTypeConfiguration<MembershipFee>
    {
        public MembershipFeeMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Table & Column Mappings
            this.ToTable("MembershipFee");
            this.Property(t => t.MemberId).HasColumnName("MemberId");
            this.Property(t => t.InvoiceId).HasColumnName("InvoiceId");
            this.Property(t => t.Year).HasColumnName("Year");
            this.Property(t => t.PaymentDate).HasColumnName("PaymentDate");
            this.Property(t => t.ExpirationDate).HasColumnName("ExpirationDate");
            this.Property(t => t.PaymentStatus).HasColumnName("PaymentStatus");
            this.Property(t => t.Amount).HasColumnName("Amount");

            // Relationships
            this.HasOptional(t => t.User)
                .WithMany(t => t.MembershipFees)
            .WillCascadeOnDelete(false);
            this.HasRequired(t => t.Member)
                .WithMany(t => t.MembershipFees)
                .HasForeignKey(d => d.MemberId)
            .WillCascadeOnDelete(false);
            this.HasRequired(t => t.Invoice)
                .WithMany(t => t.MembershipFees)
                .HasForeignKey(d => d.InvoiceId)
                .WillCascadeOnDelete(false);
            this.HasRequired(t => t.InvoiceItem)
                .WithMany(t => t.MembershipFees)
                .HasForeignKey(t => t.InvoiceItemId)
                .WillCascadeOnDelete(true);
        }
    }
}
