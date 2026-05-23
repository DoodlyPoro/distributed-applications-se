using System.Linq.Expressions;
using api.Infrastructure.RequestDTOs.Pathways;
using api.Infrastructure.ResponseDTOs.Pathways;
using Common.Entity;
using Common.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class PathwaysController : BaseController<Pathway, PathwayServices, PathwayRequest, PathwayGetRequest, PathwaysGetResponse>
{
    public PathwaysController(PathwayServices pathwayServices) : base(pathwayServices) {}

    protected override void PopulateEntity(Pathway item, PathwayRequest model, out string error)
    {
        error = null;
        
        item.Name = model.Name;
        item.Description = model.Description;
    }

    protected override void PopulateGetResponse(PathwayGetRequest request, PathwaysGetResponse response)
    {
        response.Filter = request.Filter;   
    }

    protected override Expression<Func<Pathway, bool>> GetFilter(PathwayGetRequest model)
    {
        model.Filter ??= new PathwayGetFilterRequest();
        
        return p =>
            (string.IsNullOrEmpty(model.Filter.Name) || p.Name.Contains(model.Filter.Name)) &&
            (string.IsNullOrEmpty(model.Filter.Description) || p.Description.Contains(model.Filter.Description));
    }
}