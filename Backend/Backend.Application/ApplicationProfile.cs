using AutoMapper;
using Backend.Application.Dtos;
using Backend.Domain.Entities.Concretes;
using Backend.Domain.Entities.Enums;

namespace Backend.Application;

public class ApplicationProfile : Profile
{
    public ApplicationProfile()
    {
        CreateMap<CreateProductDto, Product>()
            // .ForMember(dest => dest.ProductAttributes, opt => opt.MapFrom(src => MapProductAttributes(src)))
            // .ForMember(dest => dest.Images, opt => opt.MapFrom(src => MapImages(src.Images)))
            .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.Categories.Select(cat => new Category { Id = cat }).ToList()));

        CreateMap<Product, ProductDto>()
            // .ForMember(dest => dest.Stock, opt => opt.MapFrom(src => src.StockQuantity))
            // .ForMember(dest => dest.Variants, opt => opt.MapFrom(src => src.ProductAttributes.Select(MapProductVariant)))
            .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.Categories.Select(MapProductCategory)))
            // .ForMember(dest => dest.Images, opt => opt.MapFrom(src => MapDtoImages(src.Images.ToList())))
            .ForMember(dest => dest.Store, opt => opt.MapFrom(src => MapReducedStore(src.Store)));

        CreateMap<ProcessOrderDto, Order>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.Id))
            .ForMember(dest => dest.User, opt => opt.MapFrom(src => MapUser(src)))
            .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.OrderStatus, opt => opt.MapFrom(src => OrderStatus.Pending))
            .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => MapOrderItems(src.OrderItems)))
            .ForMember(dest => dest.PaymentTransaction, opt => opt.MapFrom(src => MapPaymentTransaction(src)));

    }

    // private static List<ProductAttribute> MapProductAttributes(CreateProductDto src)
    // {
    //     return src.Variants.Select(v => new ProductAttribute
    //     {
    //         Value = v?.Value ?? string.Empty,
    //         Image = new Image
    //         {
    //             ProductId = v?.Image?.ProductId ?? Guid.Empty,
    //             Url = v?.Image?.Url ?? string.Empty,
    //             AltText = v?.Image?.AltText ?? string.Empty,
    //             ProductAttribute = new ProductAttribute
    //             {
    //                 Id = v?.Image?.ProductAttributeId ?? Guid.Empty
    //             }
    //         },
    //         VariantId = v?.variantId ?? Guid.Empty,
    //     }).ToList();
    // }

    // private static List<Image> MapImages(ICollection<ImageDto> images)
    // {
    //     return images.Select(img => new Image
    //     {
    //         Url = img.Url,
    //         AltText = img.AltText,
    //         ProductId = img.ProductId,
    //         ProductAttribute = new ProductAttribute
    //         {
    //             Id = img.ProductAttributeId
    //         }
    //     }).ToList();
    // }

    // private static List<ImageDto> MapDtoImages(List<Image> images)
    // {
    //     return images.Select(img => new ImageDto
    //     {
    //         Url = img.Url,
    //         AltText = img.AltText,
    //         ProductId = img.ProductId,
    //         ProductAttributeId = img.ProductAttribute != null ? img.ProductAttribute.Id : Guid.Empty // Handle null ProductAttribute
    //     }).ToList();
    // }
    //
    //
    // private static ProductVariantDto MapProductVariant(ProductAttribute v)
    // {
    //     return new ProductVariantDto
    //     {
    //         Value = v.Value,
    //         Image = new ImageDto
    //         {
    //             Url = v.Image.Url,
    //             AltText = v.Image.AltText,
    //             ProductId = v.Image.ProductId,
    //             ProductAttributeId = v.Image.ProductAttribute != null ? v.Image.ProductAttribute.Id : Guid.Empty
    //         },
    //         variantId = v.VariantId,
    //         Name = v.Variant.Name
    //     };
    // }

    private static ProductCategoryDto MapProductCategory(Category cat)
    {
        return new ProductCategoryDto
        {
            Name = cat.Name,
            Subcategories = cat.SubCategories.Select(sc => sc.Name).ToList() ?? new List<string>()
        };
    }

    private static ReducedStoreDto MapReducedStore(Store store)
    {
        return new ReducedStoreDto
        {
            Id = store.Id,
            Name = store.Name,
            UserId = store.UserId,
            Description = store.Description,
            Address = store.Address,
            PhoneNumber = store.PhoneNumber
        };
    }

    private static User MapUser(ProcessOrderDto src)
    {
        return new User
        {
            Id = src.User.Id,
            Name = src.User.Name,
            Email = src.User.Email,
            Addresses = new List<UserAddress>
            {
                new UserAddress
                {
                    Address = src.UserAddress.Street,
                    City = src.UserAddress.City,
                    Country = src.UserAddress.Country
                }
            }
        };
    }

    private static List<OrderItem> MapOrderItems(IEnumerable<OrderItemDto> orderItems)
    {
        return orderItems.Select(item => new OrderItem
        {
            ProductId = item.ProductDto.Id,
            Quantity = item.Quantity,
            TotalPrice = item.Subtotal,
            Product = new Product
            {
                Id = item.ProductDto.Id
            }
        }).ToList();
    }

    private static PaymentTransaction MapPaymentTransaction(ProcessOrderDto src)
    {
        return new PaymentTransaction
        {
            Id = Guid.NewGuid(),
            PaymentMethod = src?.PaymentMethod?.PaymentMethod ?? PaymentMethod.CreditCard,
            TransactionOrderStatus = PaymentStatus.Pending,
            Amount = src?.TotalPrice ?? 0,
        };
    }
}