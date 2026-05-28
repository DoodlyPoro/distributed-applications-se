using System.Threading.Tasks;
using api.Infrastructure.ResponseDTOs.Sequences;
using FrontEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Pages.Sequences;

public class DetailsModel : AuthenticatedPageModel
{
    private readonly SequenceService _service;

    public SequenceResponse? Sequence { get; set; }

    public string? Error { get; set; }

    public DetailsModel(SequenceService service)
    {
        _service = service;
    }

    public async Task<IActionResult> OnGet(int id)
    {
        var authRedirect = redirectIfNotAuthenticated();

        if (authRedirect != null)
            return authRedirect;

        Sequence = await _service.GetById(id);

        if (Sequence == null)
        {
            Error = "Sequence not found.";
            return Page();
        }

        return Page();
    }
}