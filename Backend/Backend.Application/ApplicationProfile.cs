
using AutoMapper;
using Backend.Application.Dtos;
using Backend.Domain.Entities.Concretes;

namespace Backend.Application
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            // Mapping from ProductDto to Product
            CreateMap<ProductDto, Product>()
                .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.Categories));

            // Reverse mapping from Product to ProductDto
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.Categories));

            // Mapping from ProductCategory to Category
            CreateMap<ProductCategory, Category>()
                .ForMember(dest => dest.SubCategories, opt =>
                    opt.MapFrom(src => src.Subcategories.Select(name => new Category { Name = name }).ToList()));

            // Reverse mapping from Category to ProductCategory
            CreateMap<Category, ProductCategory>()
                .ForMember(dest => dest.Subcategories, opt =>
                    opt.MapFrom(src => src.SubCategories.Select(sub => sub.Name).ToList())); // Extract names from SubCategoriesu
            CreateMap<ProductVariantDto, ProductAttribute>();
            CreateMap<ProductAttribute, ProductVariantDto>();
        }
    }
}