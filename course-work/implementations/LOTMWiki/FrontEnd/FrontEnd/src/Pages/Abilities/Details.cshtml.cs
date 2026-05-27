using System.Threading.Tasks;
using api.Infrastructure.ResponseDTOs.Abilities;
using FrontEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Pages.Abilities;

public class DetailsModel : AuthenticatedPageModel
{
    private readonly AbilityService _service;

    public AbilityResponse? Ability { get; set; }

    public string? Error { get; set; }

    public DetailsModel(AbilityService service)
    {
        _service = service;
    }

    public async Task<IActionResult> OnGet(int id)
    {
        var authRedirect = redirectIfNotAuthenticated();

        if (authRedirect != null)
            return authRedirect;

        Ability = await _service.GetById(id);

        if (Ability == null)
        {
            Error = "Ability not found.";
            return Page();
        }

        return Page();
    }
}