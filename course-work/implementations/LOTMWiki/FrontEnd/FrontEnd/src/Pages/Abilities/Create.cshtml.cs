using System.Threading.Tasks;
using api.Infrastructure.RequestDTOs.Abilities;
using FrontEnd.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FrontEnd.Pages.Abilities;

public class CreateModel : AuthenticatedPageModel
{
    private readonly AbilityService _service;

    [BindProperty]
    public AbilityRequest Ability { get; set; } = new();
    
    public string? Error { get; set; }

    public CreateModel(AbilityService service)
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
        
        if (!ModelState.IsValid) return  Page();
        
        var success = await _service.Create(Ability);

        if (!success)
        {
            Error = "Failed to create ability";
            return Page();
        }

        return RedirectToPage("/Abilities/Index");
    }
}