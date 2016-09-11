using MemberRegistration.DAL;
using MemberRegistration.Model;
using MemberRegistration.Model.Common;
using MemberRegistration.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemberRegistration.Repository;
using Ninject.Extensions.Factory;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MemberRegistration.Repository
{
    public class DIModule : Ninject.Modules.NinjectModule
    {
        #region Methods

        public override void Load()
        {           
            Bind<IMemberRepository>().To<MemberRepository>();
            Bind<IMembershipFeeRepository>().To<MembershipFeeRepository>();
            Bind<IInvoiceIssuerRepository>().To<InvoiceIssuerRepository>();
            Bind<ICustomerRepository>().To<CustomerRepository>();
            Bind<IResponsiblePersonRepository>().To<ResponsiblePersonRepository>();
            Bind<IProductRepository>().To<ProductRepository>();
            Bind<ISocietyRepository>().To<SocietyRepository>();
            Bind<IInvoiceRepository>().To<InvoiceRepository>();
            Bind<IInvoiceItemRepository>().To<InvoiceItemRepository>();
            Bind<IActivityRepository>().To<ActivityRepository>();
            Bind<IUserRepository>().To<UserRepository>();
            
            Bind<IApplicationDbContext>().To<ApplicationDbContext>();
            Bind<IRepository>().To<Repository>();
            Bind<IUnitOfWork>().To<UnitOfWork>();
            Bind<IUnitOfWorkFactory>().ToFactory();
        }

        #endregion Methods
    }
}

