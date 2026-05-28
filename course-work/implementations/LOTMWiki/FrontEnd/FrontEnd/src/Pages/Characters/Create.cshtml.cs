using System.Threading.Tasks;
using api.Infrastructure.RequestDTOs.Characters;
using FrontEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Pages.Characters;

public class CreateModel : AuthenticatedPageModel
{
    private readonly CharacterService _service;

    [BindProperty]
    public CharacterRequest Character { get; set; } = new();

    public string? Error { get; set; }

    public CreateModel(CharacterService service)
    {
        _service = service;
    }

    public IActionResult OnGet()
    {
        var authRedirect = redirectIfNotAuthenticated();
        if (authRedirect != null) return authRedirect;

        return Page();
    }

    public async Task<IActionResult> OnPost()
    {
        var authRedirect = redirectIfNotAuthenticated();
        if (authRedirect != null) return authRedirect;

        if (!ModelState.IsValid)
            return Page();

        var success = await _service.Create(Character);

        if (!success)
        {
            Error = "Failed to create character.";
            return Page();
        }

        return RedirectToPage("/Characters/Index");
    }
}