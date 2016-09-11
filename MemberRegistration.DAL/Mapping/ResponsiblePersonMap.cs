using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MemberRegistration.DAL.Mapping
{
    public class ResponsiblePersonMap : EntityTypeConfiguration<ResponsiblePerson>
    {
        public ResponsiblePersonMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.FullName)
                .HasMaxLength(35);

            // Table & Column Mappings
            this.ToTable("ResponsiblePerson");
            this.Property(t => t.FullName).HasColumnName("FullName").HasColumnType("NVarchar");
            this.Property(t => t.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
