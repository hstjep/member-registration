using MemberRegistration.Model;
using MemberRegistration.Model.Common;
using MemberRegistration.ViewModels;
using System.Data.Entity;

namespace MemberRegistration.App_Start
{
    public static class AutoMapperConfig
    {
       public static void Initialize()
        {
            MemberRegistration.Model.Mapping.AutoMapperMaps.Initialize();

            AutoMapper.Mapper.CreateMap<MemberViewModel, MemberPOCO>().ReverseMap();
            AutoMapper.Mapper.CreateMap<MemberViewModel, IMember>().ReverseMap();

            AutoMapper.Mapper.CreateMap<MembershipFeeViewModel, MembershipFeePOCO>().ReverseMap();
            AutoMapper.Mapper.CreateMap<MembershipFeeViewModel, IMembershipFee>().ReverseMap();

            AutoMapper.Mapper.CreateMap<InvoiceIssuerViewModel, InvoiceIssuerPOCO>().ReverseMap();
            AutoMapper.Mapper.CreateMap<InvoiceIssuerViewModel, IInvoiceIssuer>().ReverseMap();

            AutoMapper.Mapper.CreateMap<CustomerViewModel, CustomerPOCO>().ReverseMap();
            AutoMapper.Mapper.CreateMap<CustomerViewModel, ICustomer>().ReverseMap();

            AutoMapper.Mapper.CreateMap<ResponsiblePersonViewModel, ResponsiblePersonPOCO>().ReverseMap();
            AutoMapper.Mapper.CreateMap<ResponsiblePersonViewModel, IResponsiblePerson>().ReverseMap();

            AutoMapper.Mapper.CreateMap<ProductViewModel, ProductPOCO>().ReverseMap();
            AutoMapper.Mapper.CreateMap<ProductViewModel, IProduct>().ReverseMap();

            AutoMapper.Mapper.CreateMap<SocietyViewModel, SocietyPOCO>().ReverseMap();
            AutoMapper.Mapper.CreateMap<SocietyViewModel, ISociety>().ReverseMap();

            AutoMapper.Mapper.CreateMap<InvoiceViewModel, InvoicePOCO>().ReverseMap();
            AutoMapper.Mapper.CreateMap<InvoiceViewModel, IInvoice>().ReverseMap();

            AutoMapper.Mapper.CreateMap<ActivityViewModel, ActivityPOCO>().ReverseMap();
            AutoMapper.Mapper.CreateMap<ActivityViewModel, IActivity>().ReverseMap();

            AutoMapper.Mapper.CreateMap<InvoiceItemViewModel, InvoiceItemPOCO>().ReverseMap();
            AutoMapper.Mapper.CreateMap<InvoiceItemViewModel, IInvoiceItem>().ReverseMap();
            AutoMapper.Mapper.CreateMap<InvoiceItemProductViewModel, InvoiceItemProductPOCO>().ReverseMap();

            AutoMapper.Mapper.CreateMap<ApplicationUserViewModel, ApplicationUserPOCO>().ReverseMap();
            AutoMapper.Mapper.CreateMap<ApplicationUserViewModel, IApplicationUser>().ReverseMap();
        }
    }
}

