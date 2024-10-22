using MediatR;
using Backend.Application.Handlers.Auth.Request.Commands;
using Backend.Domain.Entities.Concretes;
using Backend.Infrastructure.Repositories.Interfaces;

namespace Backend.Application.Handlers.Auth.RequestHandlers.Commands;

public class UserRegisterCommandHandler : IRequestHandler<UserRegisterCommand, User>
{
    private readonly IUserRepository _userRepository;
    public UserRegisterCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> Handle(UserRegisterCommand request, CancellationToken cancellationToken)
    {
        if (await _userRepository.GetUserByIdentityId(request.IdentityId) != null)
        {
            throw new Exception("User already exists.");
        }

        User user = new()
        {
            Id = Guid.NewGuid(),
            Email = request.Email,
            Name = request.Name,
            IdentityId = request.IdentityId
        };
        return await _userRepository.AddAsync(user);

    }
}
