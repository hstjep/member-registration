using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MemberRegistration.DAL.Mapping
{
    public class ActivityMap : EntityTypeConfiguration<Activity>
    {
        public ActivityMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(60);

            this.Property(t => t.Description)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("Activity");
            this.Property(t => t.CustomerId).HasColumnName("MemberId");
            this.Property(t => t.Name).HasColumnName("Name").HasColumnType("NVarchar");
            this.Property(t => t.Description).HasColumnName("Description").HasColumnType("NVarchar");
            this.Property(t => t.ActivityType).HasColumnName("ActivityType");
            this.Property(t => t.DateFrom).HasColumnName("DateFrom");
            this.Property(t => t.DateTo).HasColumnName("DateTo");
            this.Property(t => t.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Relationships
            this.HasRequired(t => t.Customer)
                .WithMany(t => t.Activities)
                .HasForeignKey(d => d.CustomerId)
                .WillCascadeOnDelete(true);
        }
    }
}
