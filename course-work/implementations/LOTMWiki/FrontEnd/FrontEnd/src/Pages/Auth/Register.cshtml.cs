using System.Threading.Tasks;
using api.Infrastructure.RequestDTOs.Users;
using FrontEnd.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FrontEnd.Pages.Auth;

public class RegisterModel : PageModel
{
    private readonly AuthService _authService;

    [BindProperty]
    public UserRequest User { get; set; } = new();

    public string? Error { get; set; }

    public RegisterModel(AuthService authService)
    {
        _authService = authService;
    }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPost()
    {
        if (!ModelState.IsValid)
            return Page();

        var success = await _authService.Register(User);

        if (!success)
        {
            Error = "Registration failed.";
            return Page();
        }

        return RedirectToPage("/Auth/Login");
    }
}