using System.Threading.Tasks;
using api.Infrastructure.ResponseDTOs.Characters;
using api.Infrastructure.ResponseDTOs.Shared;
using FrontEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Pages.Characters;

public class IndexModel : AuthenticatedPageModel
{
    private readonly CharacterService _service;

    public BaseGetResponse<CharacterResponse> Characters { get; set; } = new();

    [BindProperty(SupportsGet = true)]
    public string? Name { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? Country { get; set; }

    [BindProperty(SupportsGet = true)]
    public int? SequenceId { get; set; }

    [BindProperty(SupportsGet = true)]
    public int? PathwayId { get; set; }

    [BindProperty(SupportsGet = true)]
    public int? EpochId { get; set; }

    [BindProperty(SupportsGet = true)]
    public string OrderBy { get; set; } = "Name";

    [BindProperty(SupportsGet = true)]
    public bool SortAsc { get; set; } = true;

    [BindProperty(SupportsGet = true)]
    public int PageNumber { get; set; } = 1;

    [BindProperty(SupportsGet = true)]
    public int PageSize { get; set; } = 10;

    public IndexModel(CharacterService service)
    {
        _service = service;
    }

    public async Task<IActionResult> OnGet()
    {
        var authRedirect = redirectIfNotAuthenticated();
        if (authRedirect != null) return authRedirect;

        Characters = await _service.GetAll(
            Name, Country, SequenceId, PathwayId, EpochId,
            OrderBy, SortAsc, PageNumber, PageSize);

        return Page();
    }

    public async Task<IActionResult> OnPostDelete(int id)
    {
        var authRedirect = redirectIfNotAuthenticated();
        if (authRedirect != null) return authRedirect;

        await _service.Delete(id);

        return RedirectToPage("/Characters/Index");
    }
}