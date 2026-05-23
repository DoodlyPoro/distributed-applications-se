using System.Linq.Expressions;
using api.Infrastructure.RequestDTOs.Abilities;
using api.Infrastructure.ResponseDTOs.Abilities;
using Common.Entity;
using Common.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class AbilitiesController : BaseController<Ability, AbilityServices, AbilityRequest, AbilitiesGetRequest, AbilitiesGetResponse>
{
    public AbilitiesController(AbilityServices abilityServices) : base(abilityServices) {}
    
    protected override void PopulateEntity(Ability item, AbilityRequest model, out string error)
    {
        error = null;

        item.Name = model.Name;
        item.Description = model.Description;
        item.SequenceId = model.SequenceId;
    }

    protected override void PopulateGetResponse(AbilitiesGetRequest request, AbilitiesGetResponse response)
    {
        response.Filter = request.Filter;
    }

    protected override Expression<Func<Ability, bool>> GetFilter(AbilitiesGetRequest model)
    {
        model.Filter ??= new AbilitiesGetFilterRequest();

        return a =>
            (string.IsNullOrEmpty(model.Filter.Name) || a.Name.Contains(model.Filter.Name)) &&
            (string.IsNullOrEmpty(model.Filter.Description) || a.Description.Contains(model.Filter.Description)) &&
            (!model.Filter.SequenceId.HasValue || a.SequenceId == model.Filter.SequenceId.Value);
    }
}