using AutoMapper;
using Backend.Application.Dtos;
using Backend.Domain.Entities.Concretes;

namespace Backend.Application.Profiles;

    public class ProductAttributeProfile : Profile
    {

        public ProductAttributeProfile()
        {
            CreateMap<ProductAttribute, ProductVariantDto>()
                   .ForMember(dest => dest.variantId, opt => opt.MapFrom(src => src.VariantId))
                   .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Variant.Name))
                   .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image))
                   .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value));

            CreateMap<ProductVariantDto, ProductAttribute>()
                .ForMember(dest => dest.VariantId, opt => opt.MapFrom(src => src.variantId))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value))
                .ForMember(dest => dest.Variant, opt => opt.Ignore())
                .ForMember(dest => dest.Image, opt => opt.Ignore());
        }
    }
