using MemberRegistration.DAL;
using MemberRegistration.Model.Common;

namespace MemberRegistration.Model.Mapping
{
    public static class AutoMapperMaps
    {
        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public static void Initialize()
        {
            AutoMapper.Mapper.CreateMap<Member, MemberPOCO>().ReverseMap();
            AutoMapper.Mapper.CreateMap<Member, IMember>().ReverseMap();
            AutoMapper.Mapper.CreateMap<IMember, MemberPOCO>().ReverseMap();

            AutoMapper.Mapper.CreateMap<MembershipFee, MembershipFeePOCO>().ReverseMap();
            AutoMapper.Mapper.CreateMap<MembershipFee, IMembershipFee>().ReverseMap();
            AutoMapper.Mapper.CreateMap<IMembershipFee, MembershipFeePOCO>().ReverseMap();

            AutoMapper.Mapper.CreateMap<InvoiceIssuer, InvoiceIssuerPOCO>().ReverseMap();
            AutoMapper.Mapper.CreateMap<InvoiceIssuer, IInvoiceIssuer>().ReverseMap();
            AutoMapper.Mapper.CreateMap<IInvoiceIssuer, InvoiceIssuerPOCO>().ReverseMap();

            AutoMapper.Mapper.CreateMap<Customer, CustomerPOCO>().ReverseMap();
            AutoMapper.Mapper.CreateMap<Customer, ICustomer>().ReverseMap();
            AutoMapper.Mapper.CreateMap<ICustomer, CustomerPOCO>().ReverseMap();

            AutoMapper.Mapper.CreateMap<ResponsiblePerson, ResponsiblePersonPOCO>().ReverseMap();
            AutoMapper.Mapper.CreateMap<ResponsiblePerson, IResponsiblePerson>().ReverseMap();
            AutoMapper.Mapper.CreateMap<IResponsiblePerson, ResponsiblePersonPOCO>().ReverseMap();

            AutoMapper.Mapper.CreateMap<Product, ProductPOCO>().ReverseMap();
            AutoMapper.Mapper.CreateMap<Product, IProduct>().ReverseMap();
            AutoMapper.Mapper.CreateMap<IProduct, ProductPOCO>().ReverseMap();

            AutoMapper.Mapper.CreateMap<InvoiceItem, InvoiceItemPOCO>().ReverseMap();
            AutoMapper.Mapper.CreateMap<InvoiceItem, IInvoiceItem>().ReverseMap();
            AutoMapper.Mapper.CreateMap<IInvoiceItem, InvoiceItemPOCO>().ReverseMap();

            AutoMapper.Mapper.CreateMap<Invoice, InvoicePOCO>().ReverseMap();
            AutoMapper.Mapper.CreateMap<Invoice, IInvoice>().ReverseMap();
            AutoMapper.Mapper.CreateMap<IInvoice, InvoicePOCO>().ReverseMap();

            AutoMapper.Mapper.CreateMap<Society, SocietyPOCO>().ReverseMap();
            AutoMapper.Mapper.CreateMap<Society, ISociety>().ReverseMap();
            AutoMapper.Mapper.CreateMap<ISociety, SocietyPOCO>().ReverseMap();

            AutoMapper.Mapper.CreateMap<Activity, ActivityPOCO>().ReverseMap();
            AutoMapper.Mapper.CreateMap<Activity, IActivity>().ReverseMap();
            AutoMapper.Mapper.CreateMap<IActivity, ActivityPOCO>().ReverseMap();

            AutoMapper.Mapper.CreateMap<ApplicationUser, ApplicationUserPOCO>().ReverseMap();
            AutoMapper.Mapper.CreateMap<ApplicationUser, IApplicationUser>().ReverseMap();
            AutoMapper.Mapper.CreateMap<IApplicationUser, ApplicationUserPOCO>().ReverseMap();

            AutoMapper.Mapper.CreateMap<InvoiceItem, InvoiceItemProductPOCO>().ReverseMap();
            AutoMapper.Mapper.CreateMap<Product, InvoiceItemProductPOCO>().ReverseMap();
            AutoMapper.Mapper.CreateMap<Member, InvoiceItemProductPOCO>().ReverseMap();
            AutoMapper.Mapper.CreateMap<IInvoiceItemProduct, InvoiceItemProductPOCO>().ReverseMap();
        }
    }
}


