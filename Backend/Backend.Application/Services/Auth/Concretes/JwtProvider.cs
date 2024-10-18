using System.Net.Http.Json;
using Backend.Application.Dtos.Auth;
using Backend.Application.Services.Auth.Interfaces;

namespace Backend.Application.Services.Auth.Concretes;

public class JwtProvider : IJwtProvider
{
    private readonly HttpClient _httpClient;

    public JwtProvider(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<string?> GenerateJwtToken(string email, string password)
    {
        var request = new
        {
            email,
            password,
            returnSecureToken = true
        };

        var response = await _httpClient.PostAsJsonAsync(
            "",
            request
        );
        var authToken = await response.Content.ReadFromJsonAsync<AuthToken>();
        return authToken?.IdToken;
    }
}
