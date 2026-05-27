using System.Linq.Expressions;
using api.Infrastructure.RequestDTOs.Sequences;
using api.Infrastructure.ResponseDTOs.Sequences;
using AutoMapper;
using Common.Entity;
using Common.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class SequencesController : BaseController<Sequence, SequenceServices, SequenceRequest, SequenceGetRequest, SequenceResponse, SequencesGetResponse>
{
    public SequencesController(SequenceServices sequenceServices, IMapper mapper) : base(sequenceServices, mapper) {}

    protected override void PopulateEntity(Sequence item, SequenceRequest model, out string error)
    {
        error = null;
        
        item.Name = model.Name;
        item.Description = model.Description;
        item.Number = model.Number;
        item.PathwayId = model.PathwayId;
    }

    protected override void PopulateGetResponse(SequenceGetRequest request, SequencesGetResponse response)
    {
        response.Filter = request.Filter;
    }

    protected override Expression<Func<Sequence, bool>> GetFilter(SequenceGetRequest model)
    {
        model.Filter ??= new SequencesGetFilterRequest();

        return s =>
            (string.IsNullOrEmpty(model.Filter.Name) || s.Name.Contains(model.Filter.Name)) &&
            (string.IsNullOrEmpty(model.Filter.Description) || s.Description.Contains(model.Filter.Description)) &&
            (!model.Filter.PathwayId.HasValue || s.PathwayId == model.Filter.PathwayId.Value);
    }
}