using System.Threading.Tasks;
using api.Infrastructure.RequestDTOs.Epochs;
using FrontEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Pages.Epochs;

public class EditModel : AuthenticatedPageModel
{
    private readonly EpochService _service;

    [BindProperty]
    public EpochRequest Epoch { get; set; } = new();

    [BindProperty(SupportsGet = true)]
    public int Id { get; set; }

    public string? Error { get; set; }

    public EditModel(EpochService service)
    {
        _service = service;
    }

    public async Task<IActionResult> OnGet(int id)
    {
        var authRedirect = redirectIfNotAuthenticated();

        if (authRedirect != null)
            return authRedirect;

        Id = id;

        var epoch = await _service.GetById(id);

        if (epoch == null)
        {
            Error = "Epoch not found.";
            return Page();
        }

        Epoch = new EpochRequest
        {
            Name = epoch.Name,
            Number = epoch.Number,
            StartYear = epoch.StartYear,
            EndYear = epoch.EndYear
        };

        return Page();
    }

    public async Task<IActionResult> OnPost()
    {
        var authRedirect = redirectIfNotAuthenticated();

        if (authRedirect != null)
            return authRedirect;

        if (!ModelState.IsValid)
            return Page();

        var success = await _service.Update(Id, Epoch);

        if (!success)
        {
            Error = "Failed to update epoch.";
            return Page();
        }

        return RedirectToPage("/Epochs/Index");
    }
}