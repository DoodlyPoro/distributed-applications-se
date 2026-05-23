using System.Linq.Expressions;
using api.Infrastructure.RequestDTOs.Epochs;
using api.Infrastructure.ResponseDTOs.Epochs;
using Common.Entity;
using Common.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class EpochsController : BaseController<Epoch, EpochServices, EpochRequest, EpochsGetRequest, EpochsGetResponse>
{
    public EpochsController(EpochServices epochServices) : base(epochServices) {}
    
    protected override void PopulateEntity(Epoch item, EpochRequest model, out string error)
    {
        error = null;

        item.Name = model.Name;
        item.Number = model.Number;
        item.StartYear = model.StartYear;
        item.EndYear = model.EndYear;
    }

    protected override void PopulateGetResponse(EpochsGetRequest request, EpochsGetResponse response)
    {
        response.Filter = request.Filter;
    }

    protected override Expression<Func<Epoch, bool>> GetFilter(EpochsGetRequest model)
    {
        model.Filter ??= new EpochsGetFilterRequest();
        
        return e =>
            (string.IsNullOrEmpty(model.Filter.Name) || e.Name.Contains(model.Filter.Name)) &&
            (int.IsPositive(model.Filter.Number) || e.Number == model.Filter.Number) &&
            (int.IsPositive(model.Filter.StartYear) || e.StartYear == model.Filter.StartYear) &&
            (int.IsPositive(model.Filter.EndYear) || e.EndYear == model.Filter.EndYear);
    }
}