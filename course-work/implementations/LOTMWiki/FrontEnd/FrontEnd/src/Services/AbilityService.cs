using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using api.Infrastructure.RequestDTOs.Abilities;
using api.Infrastructure.ResponseDTOs.Abilities;
using api.Infrastructure.ResponseDTOs.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace FrontEnd.Services;

public class AbilityService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;
    private readonly IHttpContextAccessor _accessor;

    public AbilityService(HttpClient httpClient, IConfiguration configuration, IHttpContextAccessor accessor)
    {
        _httpClient = httpClient;
        _configuration = configuration;
        _accessor = accessor;

        _httpClient.BaseAddress = new Uri(_configuration["ApiSettings:BaseUrl"]);
    }

    public async Task<BaseGetResponse<AbilityResponse>> GetAll(
        string? name,
        string? description,
        int? sequenceId, 
        string orderBy = "Name", 
        bool sortAsc = true, 
        int page = 1, 
        int pageSize = 10)
    {
        JwtTokenHelper.AddJwtToken(_httpClient, _accessor);
        
        var url =
            $"abilities?" +
            $"Filter.Name={Uri.EscapeDataString(name ?? "")}" +
            $"&Filter.Description={Uri.EscapeDataString(description ?? "")}" +
            $"&Filter.SequenceId={sequenceId}" +
            $"&OrderBy={Uri.EscapeDataString(orderBy)}" +
            $"&SortAsc={sortAsc}" +
            $"&Pager.Page={page}" +
            $"&Pager.PageSize={pageSize}";
        
        var result = await _httpClient.GetFromJsonAsync<ServiceResult<BaseGetResponse<AbilityResponse>>>(url);
        
        return result.Data;
    }

    public async Task<AbilityResponse> GetById(int id)
    {
        JwtTokenHelper.AddJwtToken(_httpClient, _accessor);
        
        var result =  await _httpClient.GetFromJsonAsync<ServiceResult<AbilityResponse>>($"Abilities/{id}");
        return result.Data;
    }

    public async Task<bool> Create(AbilityRequest request)
    {
        JwtTokenHelper.AddJwtToken(_httpClient, _accessor);
        
        var result = await _httpClient.PostAsJsonAsync("abilities", request);

        return result.IsSuccessStatusCode;
    }

    public async Task<bool> Update(int id, AbilityRequest request)
    {
        JwtTokenHelper.AddJwtToken(_httpClient, _accessor);
        
        var result = await _httpClient.PutAsJsonAsync($"abilities/{id}", request);
        
        return result.IsSuccessStatusCode;       
    }

    public async Task<bool> Delete(int id)
    {
        JwtTokenHelper.AddJwtToken(_httpClient, _accessor);
        
        var result = await _httpClient.DeleteAsync($"abilities/{id}");
        
        return result.IsSuccessStatusCode;
    }
}