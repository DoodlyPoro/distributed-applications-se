using System.Threading.Tasks;
using api.Infrastructure.RequestDTOs.Pathways;
using FrontEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Pages.Pathways;

public class CreateModel : AuthenticatedPageModel
{
    private readonly PathwayService _service;

    [BindProperty]
    public PathwayRequest Pathway { get; set; } = new();

    public string? Error { get; set; }

    public CreateModel(PathwayService service)
    {
        _service = service;
    }

    public IActionResult OnGet()
    {
        var authRedirect = redirectIfNotAuthenticated();

        if (authRedirect != null)
            return authRedirect;

        return Page();
    }

    public async Task<IActionResult> OnPost()
    {
        var authRedirect = redirectIfNotAuthenticated();

        if (authRedirect != null)
            return authRedirect;

        if (!ModelState.IsValid)
            return Page();

        var success = await _service.Create(Pathway);

        if (!success)
        {
            Error = "Failed to create pathway.";
            return Page();
        }

        return RedirectToPage("/Pathways/Index");
    }
}