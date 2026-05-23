using System.Linq.Expressions;
using api.Infrastructure.RequestDTOs.Users;
using api.Infrastructure.ResponseDTOs.Users;
using Common.Entity;
using Common.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UsersController : BaseController<User, UserServices, UserRequest, UsersGetRequest, UsersGetResponse>
{
    public UsersController(UserServices userServices) : base(userServices)
    {
        
    }
    
    protected override void PopulateEntity(User item, UserRequest model, out string error)
    {
        error = null;

        item.Username = model.Username;
        item.Password = model.Password;
        item.Firstname = model.Firstname;
        item.Lastname = model.Lastname;
        item.Age = model.Age;
    }

    protected override Expression<Func<User, bool>> GetFilter(UsersGetRequest model)
    {
        model.Filter ??= new UsersGetFilterRequest();

        return u =>
            (string.IsNullOrEmpty(model.Filter.Username) || u.Username.Contains(model.Filter.Username)) &&
            (string.IsNullOrEmpty(model.Filter.FirstName) || u.Firstname.Contains(model.Filter.FirstName)) &&
            (string.IsNullOrEmpty(model.Filter.LastName) || u.Lastname.Contains(model.Filter.LastName));
    }

    protected override void PopulateGetResponse(UsersGetRequest request, UsersGetResponse response)
    {
        response.Filter = request.Filter;
    }
}