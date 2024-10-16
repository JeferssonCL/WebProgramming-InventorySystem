using AutoMapper;
using Backend.Domain.Entities.Concretes;
using Backend.Application.Dtos;

namespace Backend.Application.Profiles;
public class StoreProfile : Profile
{
    public StoreProfile()
    {
        CreateMap<Store, ReducedStoreDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
            .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber));

        CreateMap<ReducedStoreDto, Store>()
            .ForMember(dest => dest.User, opt => opt.Ignore())
            .ForMember(dest => dest.Products, opt => opt.Ignore());
    }
}
