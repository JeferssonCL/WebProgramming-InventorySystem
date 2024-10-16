using AutoMapper;
using Backend.Application.Dtos;
using Backend.Domain.Entities.Concretes;

namespace Backend.Application.Profiles;

public class ProductVariantProfile : Profile
{

    public ProductVariantProfile()
    {
        CreateMap<ProductVariant, ProductVariantDto>()
               .ForMember(dest => dest.variantId, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image))
               .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.PriceAdjustment))
               .ForMember(dest => dest.Attributes, opt => opt.MapFrom(src => src.Attributes));

        CreateMap<ProductVariantDto, ProductVariant>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.variantId))
            .ForMember(dest => dest.PriceAdjustment, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image))
            .ForMember(dest => dest.Attributes, opt => opt.MapFrom(src => src.Attributes))
            .ForMember(dest => dest.Product, opt => opt.Ignore())
            .ForMember(dest => dest.ProductId, opt => opt.Ignore())
            .ForMember(dest => dest.StockQuantity, opt => opt.Ignore())
            .ForMember(dest => dest.Id, opt => opt.Ignore());
    }
}
