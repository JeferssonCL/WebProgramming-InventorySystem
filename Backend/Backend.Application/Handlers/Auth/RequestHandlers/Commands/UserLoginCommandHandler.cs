using Backend.Application.Handlers.Auth.Request.Commands;
using Backend.Application.Services.Auth.Interfaces;
using MediatR;

namespace Backend.Application.Handlers.Auth.RequestHandlers.Commands;

public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, string?>
{
    private readonly IJwtProvider _jwtProvider;

    public UserLoginCommandHandler(IJwtProvider jwtProvider)
    {
        _jwtProvider = jwtProvider;
    }

    public async Task<string?> Handle(UserLoginCommand request, CancellationToken cancellationToken)
    {
        var token = await _jwtProvider.GenerateJwtToken(request.Email, request.Password);
        return token;
    }
}
