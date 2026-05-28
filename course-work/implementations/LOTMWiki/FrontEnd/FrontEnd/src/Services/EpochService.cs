using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using api.Infrastructure.RequestDTOs.Epochs;
using api.Infrastructure.ResponseDTOs.Epochs;
using api.Infrastructure.ResponseDTOs.Shared;
using FrontEnd.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace FrontEnd.Services;

public class EpochService
{
    private readonly HttpClient _httpClient;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public EpochService(
        HttpClient httpClient,
        IConfiguration configuration,
        IHttpContextAccessor httpContextAccessor)
    {
        _httpClient = httpClient;
        _httpContextAccessor = httpContextAccessor;
        _httpClient.BaseAddress = new Uri(configuration["ApiSettings:BaseUrl"]!);
    }

    public async Task<BaseGetResponse<EpochResponse>> GetAll(
        string? name,
        int? number,
        int? startYear,
        int? endYear,
        string orderBy = "Id",
        bool sortAsc = true,
        int page = 1,
        int pageSize = 10)
    {
        JwtTokenHelper.AddJwtToken(_httpClient, _httpContextAccessor);

        var url =
            $"epochs?" +
            $"Filter.Name={Uri.EscapeDataString(name ?? "")}" +
            $"&Filter.Number={number}" +
            $"&Filter.StartYear={startYear}" +
            $"&Filter.EndYear={endYear}" +
            $"&OrderBy={Uri.EscapeDataString(orderBy)}" +
            $"&SortAsc={sortAsc}" +
            $"&Pager.Page={page}" +
            $"&Pager.PageSize={pageSize}";

        var result =
            await _httpClient.GetFromJsonAsync<ServiceResult<BaseGetResponse<EpochResponse>>>(url);

        return result!.Data;
    }

    public async Task<EpochResponse?> GetById(int id)
    {
        JwtTokenHelper.AddJwtToken(_httpClient, _httpContextAccessor);

        var result =
            await _httpClient.GetFromJsonAsync<ServiceResult<EpochResponse>>($"epochs/{id}");

        return result?.Data;
    }

    public async Task<bool> Create(EpochRequest request)
    {
        JwtTokenHelper.AddJwtToken(_httpClient, _httpContextAccessor);

        var response = await _httpClient.PostAsJsonAsync("epochs", request);

        return response.IsSuccessStatusCode;
    }

    public async Task<bool> Update(int id, EpochRequest request)
    {
        JwtTokenHelper.AddJwtToken(_httpClient, _httpContextAccessor);

        var response = await _httpClient.PutAsJsonAsync($"epochs/{id}", request);

        return response.IsSuccessStatusCode;
    }

    public async Task<bool> Delete(int id)
    {
        JwtTokenHelper.AddJwtToken(_httpClient, _httpContextAccessor);

        var response = await _httpClient.DeleteAsync($"epochs/{id}");

        return response.IsSuccessStatusCode;
    }
}