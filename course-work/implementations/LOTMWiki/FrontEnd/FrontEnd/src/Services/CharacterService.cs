using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using api.Infrastructure.RequestDTOs.Characters;
using api.Infrastructure.ResponseDTOs.Characters;
using api.Infrastructure.ResponseDTOs.Shared;
using FrontEnd;
using FrontEnd.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

public class CharacterService
{
    private readonly HttpClient _httpClient;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CharacterService(
        HttpClient httpClient,
        IConfiguration configuration,
        IHttpContextAccessor httpContextAccessor)
    {
        _httpClient = httpClient;
        _httpContextAccessor = httpContextAccessor;
        _httpClient.BaseAddress = new Uri(configuration["ApiSettings:BaseUrl"]!);
    }

    public async Task<BaseGetResponse<CharacterResponse>> GetAll(
        string? name,
        string? country,
        int? sequenceId,
        int? pathwayId,
        int? epochId,
        string orderBy = "Name",
        bool sortAsc = true,
        int page = 1,
        int pageSize = 10)
    {
        JwtTokenHelper.AddJwtToken(_httpClient, _httpContextAccessor);

        var url =
            $"characters?" +
            $"Filter.Name={Uri.EscapeDataString(name ?? "")}" +
            $"&Filter.Country={Uri.EscapeDataString(country ?? "")}" +
            $"&Filter.SequenceId={sequenceId}" +
            $"&Filter.PathwayId={pathwayId}" +
            $"&Filter.EpochId={epochId}" +
            $"&OrderBy={Uri.EscapeDataString(orderBy)}" +
            $"&SortAsc={sortAsc}" +
            $"&Pager.Page={page}" +
            $"&Pager.PageSize={pageSize}";

        var result =
            await _httpClient.GetFromJsonAsync<ServiceResult<BaseGetResponse<CharacterResponse>>>(url);

        return result!.Data;
    }

    public async Task<CharacterResponse?> GetById(int id)
    {
        JwtTokenHelper.AddJwtToken(_httpClient, _httpContextAccessor);

        var result =
            await _httpClient.GetFromJsonAsync<ServiceResult<CharacterResponse>>($"characters/{id}");

        return result?.Data;
    }

    public async Task<bool> Create(CharacterRequest request)
    {
        JwtTokenHelper.AddJwtToken(_httpClient, _httpContextAccessor);

        var response = await _httpClient.PostAsJsonAsync("characters", request);

        return response.IsSuccessStatusCode;
    }

    public async Task<bool> Update(int id, CharacterRequest request)
    {
        JwtTokenHelper.AddJwtToken(_httpClient, _httpContextAccessor);

        var response = await _httpClient.PutAsJsonAsync($"characters/{id}", request);

        return response.IsSuccessStatusCode;
    }

    public async Task<bool> Delete(int id)
    {
        JwtTokenHelper.AddJwtToken(_httpClient, _httpContextAccessor);

        var response = await _httpClient.DeleteAsync($"characters/{id}");

        return response.IsSuccessStatusCode;
    }
}