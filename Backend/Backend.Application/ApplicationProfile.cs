
using AutoMapper;
using Backend.Application.Dtos;
using Backend.Domain.Entities.Concretes;

namespace Backend.Application
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<CreateProductDto, Product>()
             .ForMember(dest => dest.ProductAttributes, opt => opt.MapFrom(src => src.Variants.Select(v => new ProductAttribute
             {
                 Value = v.Value,
                 Image = new Image()
                 {
                     ProductId = v.Image.ProductId,
                     Url = v.Image.Url,
                     AltText = v.Image.AltText,
                     ProductAttribute = new ProductAttribute()
                     {
                         Id = v.Image.ProductAttributeId
                     }
                 },
                 VariantId = v.variantId
             }).ToList()))
             .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images.Select(
                    img => new Image
                    {
                        Url = img.Url,
                        AltText = img.AltText,
                        ProductId = img.ProductId,
                        ProductAttribute = new ProductAttribute()
                        {
                            Id = img.ProductAttributeId
                        }
                    }
                )))
             .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.Categories.Select(cat => new Category { Id = cat }).ToList()));



            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.Stock, opt => opt.MapFrom(src => src.StockQuantity))
                .ForMember(dest => dest.Variants, opt => opt.MapFrom(src => src.ProductAttributes.Select(
                   v =>
                        new ProductVariantDto()
                        {
                            Value = v.Value,
                            Image = new ImageDto()
                            {
                                Url = v.Image.Url,
                                AltText = v.Image.AltText,
                                ProductId = v.Image.ProductId,
                                ProductAttributeId = v.Image.ProductAttribute.Id
                            },
                            variantId = v.VariantId,
                            Name = v.Variant.Name
                        }
                )))
                .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.Categories.Select(cat => new ProductCategoryDto
                {
                    Name = cat.Name,
                    Subcategories = cat.SubCategories.Select(sub => sub.Name).ToList()
                }).ToList()))
                .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images.Select(
                    img => new ImageDto
                    {
                        Url = img.Url,
                        AltText = img.AltText,
                        ProductId = img.ProductId,
                        ProductAttributeId = img.ProductAttribute.Id
                    }
                )))
                .ForMember(
                    dest => dest.Store,
                    opt => opt.MapFrom(src => new ReducedStoreDto
                    {
                        Id = src.Store.Id,
                        Name = src.Store.Name,
                        UserId = src.Store.UserId,
                        Description = src.Store.Description,
                        Address = src.Store.Address,
                        PhoneNumber = src.Store.PhoneNumber
                    })
                );


        }
    }
}