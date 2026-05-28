using System.Threading.Tasks;
using api.Infrastructure.RequestDTOs.Sequences;
using FrontEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Pages.Sequences;

public class EditModel : AuthenticatedPageModel
{
    private readonly SequenceService _service;

    [BindProperty]
    public SequenceRequest Sequence { get; set; } = new();

    [BindProperty(SupportsGet = true)]
    public int Id { get; set; }

    public string? Error { get; set; }

    public EditModel(SequenceService service)
    {
        _service = service;
    }

    public async Task<IActionResult> OnGet(int id)
    {
        var authRedirect = redirectIfNotAuthenticated();

        if (authRedirect != null)
            return authRedirect;

        Id = id;

        var sequence = await _service.GetById(id);

        if (sequence == null)
        {
            Error = "Sequence not found.";
            return Page();
        }

        Sequence = new SequenceRequest
        {
            Number = sequence.Number,
            Name = sequence.Name,
            Description = sequence.Description,
            PathwayId = sequence.PathwayId
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

        var success = await _service.Update(Id, Sequence);

        if (!success)
        {
            Error = "Failed to update sequence.";
            return Page();
        }

        return RedirectToPage("/Sequences/Index");
    }
}