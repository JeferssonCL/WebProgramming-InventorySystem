using AutoMapper;
using Backend.Application.Dtos;
using Backend.Domain.Entities.Concretes;

namespace Backend.Application.Profiles;
public class ProductAttributeProfile : Profile
{
    public ProductAttributeProfile()
    {
        CreateMap<ProductAttribute, ProductAttributeDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Variant.Name))
            .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value));

        CreateMap<ProductAttributeDto, ProductAttribute>()
            .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value))
            .ForMember(dest => dest.Variant, opt => opt.MapFrom(src => new Variant { Name = src.Name ?? string.Empty }));
    }
}