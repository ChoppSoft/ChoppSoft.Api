using AutoMapper;
using ChoppSoft.Api.ViewModels;
using ChoppSoft.Domain.Models.Addresses;

namespace ChoppSoft.Api.Configurations
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Address, AddressViewModel>()
                .ForMember(p => p.CustomerName, opt => opt.MapFrom(src => src.Customer.Name));
            
            //CreateMap<AddressDto, Address>().ReverseMap();
            //CreateMap<AddressDto, Address>()
            //    .ForMember(dest => dest.NomeFornecedor, opt => opt.MapFrom(src => src.Fornecedor.Nome));
        }
    }
}
