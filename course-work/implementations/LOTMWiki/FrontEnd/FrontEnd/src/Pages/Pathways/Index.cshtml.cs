using System.Threading.Tasks;
using api.Infrastructure.ResponseDTOs.Pathways;
using api.Infrastructure.ResponseDTOs.Shared;
using FrontEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Pages.Pathways;

public class IndexModel : AuthenticatedPageModel
{
    private readonly PathwayService _service;

    public BaseGetResponse<PathwayResponse> Pathways { get; set; } = new();

    [BindProperty(SupportsGet = true)]
    public string? Name { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? Description { get; set; }

    [BindProperty(SupportsGet = true)]
    public string OrderBy { get; set; } = "Name";

    [BindProperty(SupportsGet = true)]
    public bool SortAsc { get; set; } = true;

    [BindProperty(SupportsGet = true)]
    public int PageNumber { get; set; } = 1;

    [BindProperty(SupportsGet = true)]
    public int PageSize { get; set; } = 10;

    public IndexModel(PathwayService service)
    {
        _service = service;
    }

    public async Task<IActionResult> OnGet()
    {
        var authRedirect = redirectIfNotAuthenticated();

        if (authRedirect != null)
            return authRedirect;

        Pathways = await _service.GetAll(
            Name,
            Description,
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

        return RedirectToPage("/Pathways/Index");
    }
}