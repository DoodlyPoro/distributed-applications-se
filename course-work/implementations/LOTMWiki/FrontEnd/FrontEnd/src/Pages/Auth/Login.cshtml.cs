using System;
using System.Threading.Tasks;
using FrontEnd.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FrontEnd.Pages.Auth;

public class LoginModel : PageModel
{
    private readonly AuthService _authService;

    [BindProperty]
    public string Username { get; set; } = string.Empty;

    [BindProperty] 
    public string Password { get; set; } = string.Empty;

    public string? Error { get; set; }

    public LoginModel(AuthService authService)
    {
        _authService = authService;
    }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPost()
    {
        var token = await _authService.Login(Username, Password);

        if (token == null)
        {
            Error = "Invalid username or password.";
            return Page();
        }

        HttpContext.Session.SetString("JwtToken", token);

        return RedirectToPage("/Abilities/Index");
    }
    
    public IActionResult OnPostTest()
    {
        return Page();
    }
}