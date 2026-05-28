using System.Threading.Tasks;
using api.Infrastructure.RequestDTOs.Sequences;
using FrontEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Pages.Sequences;

public class CreateModel : AuthenticatedPageModel
{
    private readonly SequenceService _service;

    [BindProperty]
    public SequenceRequest Sequence { get; set; } = new();

    public string? Error { get; set; }

    public CreateModel(SequenceService service)
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

        var success = await _service.Create(Sequence);

        if (!success)
        {
            Error = "Failed to create sequence.";
            return Page();
        }

        return RedirectToPage("/Sequences/Index");
    }
}