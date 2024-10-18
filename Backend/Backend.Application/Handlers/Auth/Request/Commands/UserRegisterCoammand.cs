using Backend.Domain.Entities.Concretes;
using MediatR;

namespace Backend.Application.Handlers.Auth.Request.Commands;

public class UserRegisterCommand : IRequest<User>
{
    public required string Email { get; set; }
    public required string Name { get; set; }
    public required string Password { get; set; }


    public UserRegisterCommand(string email, string name, string password)
    {
        Email = email;
        Name = name;
        Password = password;
    }
}
