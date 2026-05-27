using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FrontEnd.Pages;

public class AuthenticatedPageModel : PageModel
{
    protected IActionResult redirectIfNotAuthenticated()
    {
        var token = HttpContext.Session.GetString("JwtToken");

        if (string.IsNullOrEmpty(token))
            return RedirectToPage("/Auth/Login");

        return null;
    }
}