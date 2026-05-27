using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;

namespace FrontEnd.Services;

public static class JwtTokenHelper
{
    public static void AddJwtToken(HttpClient httpClient, IHttpContextAccessor accessor)
    {
        var token = accessor.HttpContext?.Session.GetString("JwtToken");

        if (!string.IsNullOrEmpty(token))
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
    }
}