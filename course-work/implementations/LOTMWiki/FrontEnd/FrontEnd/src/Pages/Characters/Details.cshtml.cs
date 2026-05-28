using System.Threading.Tasks;
using api.Infrastructure.ResponseDTOs.Characters;
using FrontEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Pages.Characters;

public class DetailsModel : AuthenticatedPageModel
{
    private readonly CharacterService _service;

    public CharacterResponse? Character { get; set; }

    public string? Error { get; set; }

    public DetailsModel(CharacterService service)
    {
        _service = service;
    }

    public async Task<IActionResult> OnGet(int id)
    {
        var authRedirect = redirectIfNotAuthenticated();
        if (authRedirect != null) return authRedirect;

        Character = await _service.GetById(id);

        if (Character == null)
        {
            Error = "Character not found.";
            return Page();
        }

        return Page();
    }
}