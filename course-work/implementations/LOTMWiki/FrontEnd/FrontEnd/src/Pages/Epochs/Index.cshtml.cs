using System.Threading.Tasks;
using api.Infrastructure.ResponseDTOs.Epochs;
using api.Infrastructure.ResponseDTOs.Shared;
using FrontEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Pages.Epochs;

public class IndexModel : AuthenticatedPageModel
{
    private readonly EpochService _service;

    public BaseGetResponse<EpochResponse> Epochs { get; set; } = new();

    [BindProperty(SupportsGet = true)]
    public string? Name { get; set; }

    [BindProperty(SupportsGet = true)]
    public int? Number { get; set; }

    [BindProperty(SupportsGet = true)]
    public int? StartYear { get; set; }

    [BindProperty(SupportsGet = true)]
    public int? EndYear { get; set; }

    [BindProperty(SupportsGet = true)]
    public string OrderBy { get; set; } = "Id";

    [BindProperty(SupportsGet = true)]
    public bool SortAsc { get; set; } = true;

    [BindProperty(SupportsGet = true)]
    public int PageNumber { get; set; } = 1;

    [BindProperty(SupportsGet = true)]
    public int PageSize { get; set; } = 10;

    public IndexModel(EpochService service)
    {
        _service = service;
    }

    public async Task<IActionResult> OnGet()
    {
        var authRedirect = redirectIfNotAuthenticated();

        if (authRedirect != null)
            return authRedirect;

        Epochs = await _service.GetAll(
            Name,
            Number,
            StartYear,
            EndYear,
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

        return RedirectToPage("/Epochs/Index");
    }
}