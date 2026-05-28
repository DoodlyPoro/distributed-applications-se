using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using api.Infrastructure.RequestDTOs.Sequences;
using api.Infrastructure.ResponseDTOs.Sequences;
using api.Infrastructure.ResponseDTOs.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace FrontEnd.Services;

public class SequenceService
{
    private readonly HttpClient _httpClient;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public SequenceService(
        HttpClient httpClient,
        IConfiguration configuration,
        IHttpContextAccessor httpContextAccessor)
    {
        _httpClient = httpClient;
        _httpContextAccessor = httpContextAccessor;
        _httpClient.BaseAddress = new Uri(configuration["ApiSettings:BaseUrl"]!);
    }

    public async Task<BaseGetResponse<SequenceResponse>> GetAll(
        string? name,
        int? number,
        string? description,
        int? pathwayId,
        string orderBy = "Id",
        bool sortAsc = true,
        int page = 1,
        int pageSize = 10)
    {
        JwtTokenHelper.AddJwtToken(_httpClient, _httpContextAccessor);

        var url =
            $"sequences?" +
            $"Filter.Name={Uri.EscapeDataString(name ?? "")}" +
            $"&Filter.Number={number}" +
            $"&Filter.Description={Uri.EscapeDataString(description ?? "")}" +
            $"&Filter.PathwayId={pathwayId}" +
            $"&OrderBy={Uri.EscapeDataString(orderBy)}" +
            $"&SortAsc={sortAsc}" +
            $"&Pager.Page={page}" +
            $"&Pager.PageSize={pageSize}";

        var result =
            await _httpClient.GetFromJsonAsync<ServiceResult<BaseGetResponse<SequenceResponse>>>(url);

        return result!.Data;
    }

    public async Task<SequenceResponse?> GetById(int id)
    {
        JwtTokenHelper.AddJwtToken(_httpClient, _httpContextAccessor);

        var result =
            await _httpClient.GetFromJsonAsync<ServiceResult<SequenceResponse>>($"sequences/{id}");

        return result?.Data;
    }

    public async Task<bool> Create(SequenceRequest request)
    {
        JwtTokenHelper.AddJwtToken(_httpClient, _httpContextAccessor);

        var response = await _httpClient.PostAsJsonAsync("sequences", request);

        return response.IsSuccessStatusCode;
    }

    public async Task<bool> Update(int id, SequenceRequest request)
    {
        JwtTokenHelper.AddJwtToken(_httpClient, _httpContextAccessor);

        var response = await _httpClient.PutAsJsonAsync($"sequences/{id}", request);

        return response.IsSuccessStatusCode;
    }

    public async Task<bool> Delete(int id)
    {
        JwtTokenHelper.AddJwtToken(_httpClient, _httpContextAccessor);

        var response = await _httpClient.DeleteAsync($"sequences/{id}");

        return response.IsSuccessStatusCode;
    }
}