using AutoMapper;
using Backend.Application.Dtos;
using Backend.Domain.Entities.Concretes;

namespace Backend.Application.Profiles;
public class ProductProfile : Profile
{

    public ProductProfile()
    {
        CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.Categories))
            .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images))
            .ReverseMap();


        CreateMap<(Product,double), ProductDto>()
            .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.Item1.Categories))
            .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Item1.Images))
            .ForMember(dest => dest.DiscountPercentage, opt => opt.MapFrom(src => src.Item2))
            .ForMember(dest => dest.PriceWithDiscount, opt => opt.MapFrom(src => src.Item1.Price * src.Item2))
            .ReverseMap();
    }
}
