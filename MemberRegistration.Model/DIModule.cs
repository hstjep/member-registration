using System;
using MemberRegistration.Model.Common;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MemberRegistration.DAL;
using System.Data.Entity;

namespace MemberRegistration.Model
{
    public class DIModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<IMember>().To<MemberPOCO>();
            Bind<IMembershipFee>().To<MembershipFeePOCO>();
            Bind<IInvoiceIssuer>().To<InvoiceIssuerPOCO>();
            Bind<ICustomer>().To<CustomerPOCO>();
            Bind<IResponsiblePerson>().To<ResponsiblePersonPOCO>();
            Bind<IProduct>().To<ProductPOCO>();
            Bind<IInvoiceItem>().To<InvoiceItemPOCO>();
            Bind<IInvoice>().To<InvoicePOCO>();
            Bind<ISociety>().To<SocietyPOCO>();
            Bind<IActivity>().To<ActivityPOCO>();

            // For roles.
            Bind<IRoleStore<IdentityRole, string>>().To<RoleStore<IdentityRole>>();
            Bind<RoleManager<IdentityRole>>().ToSelf();

            // For users.
            Bind(typeof(IUserStore<ApplicationUser, Guid>)).To(typeof(CustomUserStore));
            Bind(typeof(UserManager<ApplicationUser, Guid>)).ToSelf();
            Bind(typeof(DbContext)).To(typeof(ApplicationDbContext));
        }
    }
}


