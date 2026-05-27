using System;
using System.Threading.Tasks;
using api.Infrastructure.ResponseDTOs.Abilities;
using api.Infrastructure.ResponseDTOs.Shared;
using FrontEnd.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FrontEnd.Pages.Abilities;

public class IndexModel : AuthenticatedPageModel
{
    private readonly AbilityService _service;
    public BaseGetResponse<AbilityResponse> Abilities { get; set; } = new();
    
    [BindProperty(SupportsGet = true)]
    public string? Name { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? Description { get; set; }

    [BindProperty(SupportsGet = true)]
    public int? SequenceId { get; set; }

    [BindProperty(SupportsGet = true)]
    public string OrderBy { get; set; } = "Name";

    [BindProperty(SupportsGet = true)]
    public bool SortAsc { get; set; } = true;

    [BindProperty(SupportsGet = true)]
    public int PageNumber { get; set; } = 1;

    [BindProperty(SupportsGet = true)]
    public int PageSize { get; set; } = 10;

    public IndexModel(AbilityService service)
    {
        _service = service;
    }

    public async Task<IActionResult> OnGet()
    {
        var authRedirect = redirectIfNotAuthenticated();
        
        if (authRedirect != null) return authRedirect;
        
        Abilities = await _service.GetAll(
            Name,
            Description,
            SequenceId,
            OrderBy,
            SortAsc,
            PageNumber,
            PageSize);

        return Page();
    }
    
    public async Task<IActionResult> OnPostDelete(int id)
    {
        var authRedirect = redirectIfNotAuthenticated();

        if (authRedirect != null)
            return authRedirect;

        await _service.Delete(id);

        return RedirectToPage("/Abilities/Index");
    }
}