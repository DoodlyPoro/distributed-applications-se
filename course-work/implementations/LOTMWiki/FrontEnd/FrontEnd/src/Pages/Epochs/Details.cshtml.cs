using System.Threading.Tasks;
using api.Infrastructure.ResponseDTOs.Epochs;
using FrontEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Pages.Epochs;

public class DetailsModel : AuthenticatedPageModel
{
    private readonly EpochService _service;

    public EpochResponse? Epoch { get; set; }

    public string? Error { get; set; }

    public DetailsModel(EpochService service)
    {
        _service = service;
    }

    public async Task<IActionResult> OnGet(int id)
    {
        var authRedirect = redirectIfNotAuthenticated();

        if (authRedirect != null)
            return authRedirect;

        Epoch = await _service.GetById(id);

        if (Epoch == null)
        {
            Error = "Epoch not found.";
            return Page();
        }

        return Page();
    }
}