using Backend.Application.Services.Auth.Interfaces;
using FirebaseAdmin.Auth;

namespace Backend.Application.Services.Auth.Concretes;

public class AuthenticationService : IAuthenticationService
{
    public async Task<string> RegisterAsync(string email, string password)
    {
        var userArgs = new UserRecordArgs
        {
            Email = email,
            Password = password
        };

        var userRecord = await FirebaseAuth.DefaultInstance.CreateUserAsync(userArgs);
        return userRecord.Uid;
    }
}
