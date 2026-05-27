using System.Threading.Tasks;
using api.Infrastructure.RequestDTOs.Abilities;
using FrontEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Pages.Abilities;

public class EditModel : AuthenticatedPageModel
{
    private readonly AbilityService _service;

    [BindProperty]
    public AbilityRequest Ability { get; set; } = new();

    [BindProperty(SupportsGet = true)]
    public int Id { get; set; }

    public string? Error { get; set; }

    public EditModel(AbilityService service)
    {
        _service = service;
    }

    public async Task<IActionResult> OnGet(int id)
    {
        var authRedirect = redirectIfNotAuthenticated();

        if (authRedirect != null)
            return authRedirect;

        Id = id;

        var ability = await _service.GetById(id);

        if (ability == null)
        {
            Error = "Ability not found.";
            return Page();
        }

        Ability = new AbilityRequest
        {
            Name = ability.Name,
            Description = ability.Description,
            SequenceId = ability.SequenceId
        };

        return Page();
    }

    public async Task<IActionResult> OnPost()
    {
        var authRedirect = redirectIfNotAuthenticated();

        if (authRedirect != null)
            return authRedirect;

        if (!ModelState.IsValid)
            return Page();

        var success = await _service.Update(Id, Ability);

        if (!success)
        {
            Error = "Failed to update ability.";
            return Page();
        }

        return RedirectToPage("/Abilities/Index");
    }
}