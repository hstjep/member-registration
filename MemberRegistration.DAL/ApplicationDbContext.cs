using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using MemberRegistration.DAL.Mapping;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Threading.Tasks;

namespace MemberRegistration.DAL
{
    public class CustomRole : IdentityRole<Guid, CustomUserRole>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomRole"/> class.
        /// </summary>
        public CustomRole() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomRole"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public CustomRole(string name) { Name = name; }
    }

    public class CustomUserRole : IdentityUserRole<Guid> { }
    public class CustomUserClaim : IdentityUserClaim<Guid> { }
    public class CustomUserLogin : IdentityUserLogin<Guid> { }

    /// <summary>
    /// The application database context.
    /// </summary>
    /// <seealso cref="Microsoft.AspNet.Identity.EntityFramework.IdentityDbContext{MemberRegistration.DAL.ApplicationUser, MemberRegistration.DAL.CustomRole, System.Guid, MemberRegistration.DAL.CustomUserLogin, MemberRegistration.DAL.CustomUserRole, MemberRegistration.DAL.CustomUserClaim}" />
    /// <seealso cref="MemberRegistration.DAL.IApplicationDbContext" />
    public partial class ApplicationDbContext : IdentityDbContext<ApplicationUser, CustomRole, Guid, CustomUserLogin, CustomUserRole, CustomUserClaim>,IApplicationDbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>ApplicationDbContext instance.</returns>
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<MembershipFee> MembershipFees { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<InvoiceIssuer> InvoiceIssuers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ResponsiblePerson> ResponsiblePeople { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Society> Societys { get; set; }
        public DbSet<Activity> Activities { get; set; }

        /// <summary>
        /// Maps table names, and sets up relationships between the various user entities.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MembershipFeeMap());
            modelBuilder.Configurations.Add(new MemberMap());
            modelBuilder.Configurations.Add(new InvoiceIssuerMap());
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new ResponsiblePersonMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new InvoiceItemMap());
            modelBuilder.Configurations.Add(new InvoiceMap());
            modelBuilder.Configurations.Add(new SocietyMap());
            modelBuilder.Configurations.Add(new ActivityMap());
            base.OnModelCreating(modelBuilder);
        }        
    }

    /// <summary>
    /// The application database context.
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public interface IApplicationDbContext : IDisposable
    {
        DbSet<MembershipFee> MembershipFees { get; set; }
        DbSet<Member> Members { get; set; }
        DbSet<InvoiceIssuer> InvoiceIssuers { get; set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<ResponsiblePerson> ResponsiblePeople { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<InvoiceItem> InvoiceItems { get; set; }
        DbSet<Invoice> Invoices { get; set; }
        DbSet<Society> Societys { get; set; }

        /// <summary>
        /// Sets this instance.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <returns></returns>
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        /// <summary>
        /// Entries the specified entity.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        /// <summary>
        /// Saves the changes asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<int> SaveChangesAsync();
    }

    public class CustomUserStore : UserStore<ApplicationUser, CustomRole, Guid, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomUserStore"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public CustomUserStore(ApplicationDbContext context)
            : base(context)
        {
        }
    }

    public class CustomRoleStore : RoleStore<CustomRole, Guid, CustomUserRole>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomRoleStore"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public CustomRoleStore(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}


