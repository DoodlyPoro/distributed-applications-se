using System.Threading.Tasks;
using api.Infrastructure.RequestDTOs.Epochs;
using FrontEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Pages.Epochs;

public class CreateModel : AuthenticatedPageModel
{
    private readonly EpochService _service;

    [BindProperty]
    public EpochRequest Epoch { get; set; } = new();

    public string? Error { get; set; }

    public CreateModel(EpochService service)
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

        var success = await _service.Create(Epoch);

        if (!success)
        {
            Error = "Failed to create epoch.";
            return Page();
        }

        return RedirectToPage("/Epochs/Index");
    }
}