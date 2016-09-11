using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MemberRegistration.DAL.Mapping
{
    public class MemberMap : EntityTypeConfiguration<Member>
    {
        public MemberMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Table & Column Mappings
            this.ToTable("Members");        
            this.Property(t => t.MembershipNumber).HasColumnName("MembershipNumber");
            this.Property(t => t.OIB).HasColumnName("OIB").HasColumnType("Varchar").HasMaxLength(11);
            this.Property(t => t.BirthPlace).HasColumnName("BirthPlace").HasColumnType("NVarchar").HasMaxLength(60);
            this.Property(t => t.BirthDate).HasColumnName("BirthDate");
            this.Property(t => t.PhoneNumber).HasColumnName("PhoneNumber").HasColumnType("Varchar").HasMaxLength(30);
            this.Property(t => t.CurrentEmployment).HasColumnName("CurrentEmployment").HasColumnType("NVarchar").HasMaxLength(200);
            this.Property(t => t.Email).HasColumnName("Email").HasColumnType("Varchar").HasMaxLength(100).IsRequired();
            this.Property(t => t.WebSite).HasColumnName("WebSite").HasColumnType("Varchar").HasMaxLength(50);
            this.Property(t => t.AreaOfInterest).HasColumnName("AreaOfInterest").HasColumnType("NVarchar").HasMaxLength(300);
            this.Property(t => t.MembershipDate).HasColumnName("MembershipDate");
            this.Property(t => t.Status).HasColumnName("Status");

            // Relationships
            this.HasRequired(t => t.User)
                .WithOptional(t => t.Member)
                .WillCascadeOnDelete(true);
        }
    }
}
