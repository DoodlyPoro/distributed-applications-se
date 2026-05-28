using System.Threading.Tasks;
using api.Infrastructure.RequestDTOs.Pathways;
using FrontEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Pages.Pathways;

public class EditModel : AuthenticatedPageModel
{
    private readonly PathwayService _service;

    [BindProperty]
    public PathwayRequest Pathway { get; set; } = new();

    [BindProperty(SupportsGet = true)]
    public int Id { get; set; }

    public string? Error { get; set; }

    public EditModel(PathwayService service)
    {
        _service = service;
    }

    public async Task<IActionResult> OnGet(int id)
    {
        var authRedirect = redirectIfNotAuthenticated();

        if (authRedirect != null)
            return authRedirect;

        Id = id;

        var pathway = await _service.GetById(id);

        if (pathway == null)
        {
            Error = "Pathway not found.";
            return Page();
        }

        Pathway = new PathwayRequest
        {
            Name = pathway.Name,
            Description = pathway.Description
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

        var success = await _service.Update(Id, Pathway);

        if (!success)
        {
            Error = "Failed to update pathway.";
            return Page();
        }

        return RedirectToPage("/Pathways/Index");
    }
}