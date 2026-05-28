using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using api.Infrastructure.RequestDTOs.Users;
using FrontEnd.DTOs.Responses.Auth;
using Microsoft.Extensions.Configuration;

namespace FrontEnd.Services;

public class AuthService
{
    private readonly HttpClient _httpClient;
    
    public AuthService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri(configuration["ApiSettings:BaseUrl"]!);
    }

    public async Task<string?> Login(string username, string password)
    {
        var form = new MultipartFormDataContent
        {
            { new StringContent(username ?? string.Empty), "Username" },
            { new StringContent(password ?? string.Empty), "Password" }
        };
        
        var response = await _httpClient.PostAsync("Auth", form);
        
        if (!response.IsSuccessStatusCode)
            return null;
        
        var result = await response.Content.ReadFromJsonAsync<TokenResponse>();

        return result?.Token;
    }
    
    public async Task<bool> Register(UserRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync("users", request);

        return response.IsSuccessStatusCode;
    }
}