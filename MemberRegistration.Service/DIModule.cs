using MemberRegistration.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistration.Service
{
    #region Methods

    public class DIModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<IMemberService>().To<MemberService>();
            Bind<IMembershipFeeService>().To<MembershipFeeService>();
            Bind<IInvoiceIssuerService>().To<InvoiceIssuerService>();
            Bind<ICustomerService>().To<CustomerService>();
            Bind<IResponsiblePersonService>().To<ResponsiblePersonService>();
            Bind<IProductService>().To<ProductService>();
            Bind<ISocietyService>().To<SocietyService>();
            Bind<IInvoiceService>().To<InvoiceService>();
            Bind<IInvoiceItemService>().To<InvoiceItemService>();
            Bind<IActivityService>().To<ActivityService>();
            Bind<IUserService>().To<UserService>();
        }
    }

    #endregion Methods
}
