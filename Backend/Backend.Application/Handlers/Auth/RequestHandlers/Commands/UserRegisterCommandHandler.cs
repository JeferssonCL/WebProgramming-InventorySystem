using MediatR;
using Backend.Application.Handlers.Auth.Request.Commands;
using Backend.Domain.Entities.Concretes;
using Backend.Application.Services.Auth.Interfaces;
using Backend.Infrastructure.Repositories.Interfaces;

namespace Backend.Application.Handlers.Auth.RequestHandlers.Commands;

public class UserRegisterCommandHandler : IRequestHandler<UserRegisterCommand, User>
{
    private readonly IAuthenticationService _authenticationService;

    private readonly IUserRepository _userRepository;
    public UserRegisterCommandHandler(IAuthenticationService authenticationService, IUserRepository userRepository)
    {
        _authenticationService = authenticationService;
        _userRepository = userRepository;
    }

    public async Task<User> Handle(UserRegisterCommand request, CancellationToken cancellationToken)
    {
        var identityId = await _authenticationService.RegisterAsync(request.Email, request.Password);
        User user = new()
        {
            Id = Guid.NewGuid(),
            Email = request.Email,
            Name = request.Name,
            IdentityId = identityId
        };

        return await _userRepository.AddAsync(user);

    }
}
