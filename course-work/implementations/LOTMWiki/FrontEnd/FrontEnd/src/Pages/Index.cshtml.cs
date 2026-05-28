using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FrontEnd.Pages;

public class IndexModel : AuthenticatedPageModel
{
    public IActionResult OnGet()
    {
        var authRedirect = redirectIfNotAuthenticated();

        if (authRedirect != null)
            return authRedirect;

        return Page();
    }
    
    public IActionResult OnPostLogout()
    {
        HttpContext.Session.Remove("JWToken");

        return RedirectToPage("/Auth/Login");
    }
}