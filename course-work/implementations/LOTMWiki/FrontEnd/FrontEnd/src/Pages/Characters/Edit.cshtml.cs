using System.Threading.Tasks;
using api.Infrastructure.RequestDTOs.Characters;
using FrontEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Pages.Characters;

public class EditModel : AuthenticatedPageModel
{
    private readonly CharacterService _service;

    [BindProperty]
    public CharacterRequest Character { get; set; } = new();

    [BindProperty(SupportsGet = true)]
    public int Id { get; set; }

    public string? Error { get; set; }

    public EditModel(CharacterService service)
    {
        _service = service;
    }

    public async Task<IActionResult> OnGet(int id)
    {
        var authRedirect = redirectIfNotAuthenticated();
        if (authRedirect != null) return authRedirect;

        Id = id;

        var character = await _service.GetById(id);

        if (character == null)
        {
            Error = "Character not found.";
            return Page();
        }

        Character = new CharacterRequest
        {
            Name = character.Name,
            Country = character.Country,
            SequenceId = character.SequenceId,
            PathwayId = character.PathwayId,
            EpochId = character.EpochId
        };

        return Page();
    }

    public async Task<IActionResult> OnPost()
    {
        var authRedirect = redirectIfNotAuthenticated();
        if (authRedirect != null) return authRedirect;

        if (!ModelState.IsValid)
            return Page();

        var success = await _service.Update(Id, Character);

        if (!success)
        {
            Error = "Failed to update character.";
            return Page();
        }

        return RedirectToPage("/Characters/Index");
    }
}