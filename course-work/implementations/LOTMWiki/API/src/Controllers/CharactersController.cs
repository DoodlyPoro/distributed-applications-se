using System.Linq.Expressions;
using api.Infrastructure.RequestDTOs.Characters;
using api.Infrastructure.ResponseDTOs.Characters;
using AutoMapper;
using Common.Entity;
using Common.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class CharactersController :  BaseController<Character, CharacterServices, CharacterRequest, CharactersGetRequest, CharacterResponse, CharactersGetResponse>
{
    public CharactersController(CharacterServices characterServices, IMapper mapper) : base(characterServices, mapper) {}

    protected override void PopulateEntity(Character item, CharacterRequest model, out string error)
    {
        error = null;

        item.Name = model.Name;
        item.Country = model.Country;
        item.EpochId = model.EpochId;
        item.SequenceId = model.SequenceId;
        item.PathwayId = model.PathwayId;
    }

    protected override void PopulateGetResponse(CharactersGetRequest request, CharactersGetResponse response)
    {
        response.Filter = request.Filter;
    }

    protected override Expression<Func<Character, bool>> GetFilter(CharactersGetRequest model)
    {
        model.Filter ??= new CharactersGetFilterRequest();
        
        return c =>
            (string.IsNullOrEmpty(model.Filter.Name) || c.Name.Contains(model.Filter.Name)) &&
            (string.IsNullOrEmpty(model.Filter.Country) || c.Country.Contains(model.Filter.Country)) &&
            (!model.Filter.EpochId.HasValue || c.EpochId == model.Filter.EpochId.Value) &&
            (!model.Filter.SequenceId.HasValue || c.SequenceId == model.Filter.SequenceId.Value) &&
            (!model.Filter.PathwayId.HasValue || c.PathwayId == model.Filter.PathwayId.Value);
    }
}