using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using api.Infrastructure.RequestDTOs.Pathways;
using api.Infrastructure.ResponseDTOs.Pathways;
using api.Infrastructure.ResponseDTOs.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace FrontEnd.Services;

public class PathwayService
{
    private readonly HttpClient _httpClient;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public PathwayService(
        HttpClient httpClient,
        IConfiguration configuration,
        IHttpContextAccessor httpContextAccessor)
    {
        _httpClient = httpClient;
        _httpContextAccessor = httpContextAccessor;
        _httpClient.BaseAddress = new Uri(configuration["ApiSettings:BaseUrl"]!);
    }

    public async Task<BaseGetResponse<PathwayResponse>> GetAll(
        string? name,
        string? description,
        string orderBy = "Name",
        bool sortAsc = true,
        int page = 1,
        int pageSize = 10)
    {
        JwtTokenHelper.AddJwtToken(_httpClient, _httpContextAccessor);

        var url =
            $"pathways?" +
            $"Filter.Name={Uri.EscapeDataString(name ?? "")}" +
            $"&Filter.Description={Uri.EscapeDataString(description ?? "")}" +
            $"&OrderBy={Uri.EscapeDataString(orderBy)}" +
            $"&SortAsc={sortAsc}" +
            $"&Pager.Page={page}" +
            $"&Pager.PageSize={pageSize}";

        var result =
            await _httpClient.GetFromJsonAsync<ServiceResult<BaseGetResponse<PathwayResponse>>>(url);

        return result!.Data;
    }

    public async Task<PathwayResponse?> GetById(int id)
    {
        JwtTokenHelper.AddJwtToken(_httpClient, _httpContextAccessor);

        var result =
            await _httpClient.GetFromJsonAsync<ServiceResult<PathwayResponse>>($"pathways/{id}");

        return result?.Data;
    }

    public async Task<bool> Create(PathwayRequest request)
    {
        JwtTokenHelper.AddJwtToken(_httpClient, _httpContextAccessor);

        var response = await _httpClient.PostAsJsonAsync("pathways", request);

        return response.IsSuccessStatusCode;
    }

    public async Task<bool> Update(int id, PathwayRequest request)
    {
        JwtTokenHelper.AddJwtToken(_httpClient, _httpContextAccessor);

        var response = await _httpClient.PutAsJsonAsync($"pathways/{id}", request);

        return response.IsSuccessStatusCode;
    }

    public async Task<bool> Delete(int id)
    {
        JwtTokenHelper.AddJwtToken(_httpClient, _httpContextAccessor);

        var response = await _httpClient.DeleteAsync($"pathways/{id}");

        return response.IsSuccessStatusCode;
    }
}