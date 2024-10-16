using AutoMapper;
using Backend.Domain.Entities.Concretes;
using Backend.Application.Dtos;

namespace Backend.Application.Profiles;
public class StoreProfile : Profile
{
    public StoreProfile()
    {
        CreateMap<Store, ReducedStoreDto>();

        CreateMap<ReducedStoreDto, Store>()
            .ForMember(dest => dest.User, opt => opt.Ignore())
            .ForMember(dest => dest.Products, opt => opt.Ignore());
    }
}
