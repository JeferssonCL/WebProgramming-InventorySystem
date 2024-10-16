using AutoMapper;
using Backend.Application.Dtos;
using Backend.Domain.Entities.Concretes;

namespace Backend.Application.Profiles;

    public class ImageProfile : Profile
    {

        public ImageProfile()
        {
            CreateMap<Image, ImageDto>()
               .ForMember(dest => dest.ProductAttributeId, opt => opt.MapFrom(src => src.ProductAttribute.Id))
               .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
               .ForMember(dest => dest.AltText, opt => opt.MapFrom(src => src.AltText))
               .ForMember(dest => dest.Url, opt => opt.MapFrom(src => src.Url));

            CreateMap<ImageDto, Image>()
                .ForMember(dest => dest.ProductAttribute, opt => opt.Ignore())
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.AltText, opt => opt.MapFrom(src => src.AltText))
                .ForMember(dest => dest.Url, opt => opt.MapFrom(src => src.Url));
        }

    }
