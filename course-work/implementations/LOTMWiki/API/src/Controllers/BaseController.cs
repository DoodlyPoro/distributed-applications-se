using System.Linq.Expressions;
using api.Infrastructure.RequestDTOs.Shared;
using api.Infrastructure.ResponseDTOs.Shared;
using api.Services;
using AutoMapper;
using Common;
using Common.Entity;
using Common.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BaseController<E, EService, ERequest,EGetRequest, EResponse, EGetResponse> : ControllerBase
where E : BaseEntity, new()
where EService : BaseService<E>
where ERequest : class, new()
where EGetRequest : BaseGetRequest, new()
where EResponse : class, new()
where EGetResponse : BaseGetResponse<EResponse>, new()
{
    protected readonly EService Service;
    protected readonly IMapper Mapper;

    public BaseController(EService service, IMapper mapper)
    {
        Service = service;
        Mapper = mapper;
    }
    
    protected virtual void PopulateEntity(E item, ERequest model, out string error)
    { error = null; }

    protected virtual Expression<Func<E, bool>> GetFilter(EGetRequest request)
    { return null; }
    
    protected virtual void PopulateGetResponse(EGetRequest request, EGetResponse response)
    { }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] EGetRequest model)
    {
        model.Pager = model.Pager ?? new PagerRequest();
        model.Pager.Page = model.Pager.Page <= 0 ? 1 : model.Pager.Page;
        model.Pager.PageSize = model.Pager.PageSize <= 0 ? 10 : model.Pager.PageSize;
        model.OrderBy ??= nameof(BaseEntity.Id);
        model.OrderBy = typeof(E).GetProperty(model.OrderBy) != null ? model.OrderBy : nameof(BaseEntity.Id);

        Expression<Func<E, bool>> filter = GetFilter(model);
        
        var response = new EGetResponse();

        response.Pager = new PagerResponse();
        response.Pager.Page = model.Pager.Page;
        response.Pager.PageSize = model.Pager.PageSize;
        response.OrderBy = model.OrderBy;
        response.SortAsc = model.SortAsc;
        
        PopulateGetResponse(model, response);

        response.Pager.Count = await Service.Count(filter);
        var entities = await Service.GetAll(
            filter,
            model.OrderBy,
            model.SortAsc,
            model.Pager.Page,
            model.Pager.PageSize);
        
        response.Items = Mapper.Map<List<EResponse>>(entities);

        return Ok(ServiceResult<EGetResponse>.Success(response));
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> Get([FromRoute] int id)
    {
        var item = await Service.GetById(id);
        var response = Mapper.Map<EResponse>(item);
        return Ok(ServiceResult<EResponse>.Success(response));
    }

    [HttpPost]
    public virtual async Task<IActionResult> Post([FromBody] ERequest model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        E item = new E();
        PopulateEntity(item, model, out string error);
        if (!string.IsNullOrEmpty(error))
            return BadRequest(ServiceResult<ERequest>.Fail(model,
                new List<Error>
                {
                    new Error
                    {
                        Key = "Global",
                        Messages = new List<string>() { error }
                    }
                }));

        await Service.Save(item);
        return Ok(ServiceResult<E>.Success(item));
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Put([FromRoute] int id, [FromBody] ERequest model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        E forUpdate = await Service.GetById(id);
        if (forUpdate == null)
            throw new Exception($"{typeof(E).Name} not found");
        
        PopulateEntity(forUpdate, model, out string error);
        if (!string.IsNullOrEmpty(error))
            return BadRequest(ServiceResult<ERequest>.Fail(model,
                new List<Error>
                {
                    new Error
                    {
                        Key = "Global",
                        Messages = new List<string>() { error }
                    }
                }));

        await Service.Save(forUpdate);
        return Ok(ServiceResult<E>.Success(forUpdate));
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        E forDelete = await Service.GetById(id);
        if (forDelete == null)
            throw new Exception($"{typeof(E).Name} not found");
        
        await Service.Delete(forDelete);
        return Ok(ServiceResult<E>.Success(forDelete));
    }
}