using AutoMapper;
using Backend.Application.Dtos;
using Backend.Domain.Entities.Concretes;

namespace Backend.Application.Profiles;

public class CategoryProfile : Profile
{

    public CategoryProfile()
    {
        CreateMap<Category, ProductCategoryDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Subcategories, opt => opt.MapFrom(src => src.SubCategories.Select(sub => sub.Name).ToList()));


        CreateMap<ProductCategoryDto, Category>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.SubCategories, opt => opt.MapFrom(src => src.Subcategories.Select(sub => new Category { Name = sub }).ToList()));
    }
}