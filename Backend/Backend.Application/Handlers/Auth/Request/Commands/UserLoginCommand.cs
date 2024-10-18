using MediatR;

namespace Backend.Application.Handlers.Auth.Request.Commands;

public class UserLoginCommand : IRequest<string?>
{
    public string Email { get; set; }
    public string Password { get; set; }

    public UserLoginCommand(string email, string password)
    {
        Email = email;
        Password = password;
    }
}
