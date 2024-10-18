namespace Backend.Application.Services.Auth.Interfaces;

public interface IJwtProvider
{
    Task<string?> GenerateJwtToken(string email, string password);
}
