namespace Backend.Application.Services.Auth.Interfaces;


public interface IAuthenticationService
{
    Task<string> RegisterAsync(string email, string password);

}
