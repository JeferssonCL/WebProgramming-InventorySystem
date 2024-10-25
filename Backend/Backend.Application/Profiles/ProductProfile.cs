using AutoMapper;
using Backend.Application.Dtos;
using Backend.Domain.Entities.Concretes;

namespace Backend.Application.Profiles;
public class ProductProfile : Profile
{

    public ProductProfile()
    {

        /*
            TODO: Add mapping for CreateProductDto
                 CreateMap<CreateProductDto, Product>()
                    .ForMember(dest => dest.ProductVariants, opt => opt.MapFrom(src => src.Variants))
                    .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images))
                    .ForMember(dest => dest.BasePrice, opt => opt.MapFrom(src => src.Price))
                    .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.Categories.Select(cat => new Category { Id = cat }).ToList()));
         */

        CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.Variants, opt => opt.MapFrom(src => src.ProductVariants))
            .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.Categories))
            .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images))
            .ForMember(dest => dest.Store, opt => opt.MapFrom(src => src.Store))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.BasePrice))
            .ReverseMap();
    }

}
