using System.Threading.Tasks;
using api.Infrastructure.ResponseDTOs.Pathways;
using FrontEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Pages.Pathways;

public class DetailsModel : AuthenticatedPageModel
{
    private readonly PathwayService _service;

    public PathwayResponse? Pathway { get; set; }

    public string? Error { get; set; }

    public DetailsModel(PathwayService service)
    {
        _service = service;
    }

    public async Task<IActionResult> OnGet(int id)
    {
        var authRedirect = redirectIfNotAuthenticated();

        if (authRedirect != null)
            return authRedirect;

        Pathway = await _service.GetById(id);

        if (Pathway == null)
        {
            Error = "Pathway not found.";
            return Page();
        }

        return Page();
    }
}