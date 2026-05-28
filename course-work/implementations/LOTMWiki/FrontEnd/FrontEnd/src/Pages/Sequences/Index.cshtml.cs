using System.Threading.Tasks;
using api.Infrastructure.ResponseDTOs.Sequences;
using api.Infrastructure.ResponseDTOs.Shared;
using FrontEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Pages.Sequences;

public class IndexModel : AuthenticatedPageModel
{
    private readonly SequenceService _service;

    public BaseGetResponse<SequenceResponse> Sequences { get; set; } = new();

    [BindProperty(SupportsGet = true)]
    public string? Name { get; set; }

    [BindProperty(SupportsGet = true)]
    public int? Number { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? Description { get; set; }

    [BindProperty(SupportsGet = true)]
    public int? PathwayId { get; set; }

    [BindProperty(SupportsGet = true)]
    public string OrderBy { get; set; } = "Id";

    [BindProperty(SupportsGet = true)]
    public bool SortAsc { get; set; } = true;

    [BindProperty(SupportsGet = true)]
    public int PageNumber { get; set; } = 1;

    [BindProperty(SupportsGet = true)]
    public int PageSize { get; set; } = 10;

    public IndexModel(SequenceService service)
    {
        _service = service;
    }

    public async Task<IActionResult> OnGet()
    {
        var authRedirect = redirectIfNotAuthenticated();

        if (authRedirect != null)
            return authRedirect;

        Sequences = await _service.GetAll(
            Name,
            Number,
            Description,
            PathwayId,
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

        return RedirectToPage("/Sequences/Index");
    }
}