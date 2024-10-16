using AutoMapper;
using Backend.Application.Dtos.User;
using Backend.Domain.Entities.Concretes;

namespace Backend.Application.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDto>();
        CreateMap<UserDto, User>();
    }
}
