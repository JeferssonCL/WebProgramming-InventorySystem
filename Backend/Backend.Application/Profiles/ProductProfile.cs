using AutoMapper;
using Backend.Application.Dtos;
using Backend.Domain.Entities.Concretes;

namespace Backend.Application.Profiles;
public class ProductProfile : Profile
{

    public ProductProfile()
    {
        CreateMap<CreateProductDto, Product>()
            .ForMember(dest => dest.ProductAttributes, opt => opt.MapFrom(src => src.Variants))
            .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images))
            .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.Categories.Select(cat => new Category { Id = cat }).ToList()));


        CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.Stock, opt => opt.MapFrom(src => src.StockQuantity))
            .ForMember(dest => dest.Variants, opt => opt.MapFrom(src => src.ProductAttributes))
            .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.Categories))
            .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images))
            .ForMember(dest => dest.Store, opt => opt.MapFrom(src => src.Store))
            .ReverseMap();
    }

}