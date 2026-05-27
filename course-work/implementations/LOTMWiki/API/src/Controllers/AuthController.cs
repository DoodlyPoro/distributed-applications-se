using api.Infrastructure.RequestDTOs.Auth;
using api.Services;
using Common;
using Common.Entity;
using Common.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly UserServices userServices;
    public AuthController(UserServices userServices)
    {
        this.userServices = userServices;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateToken([FromForm] AuthTokenRequest tokenRequest)
    {
        if (!ModelState.IsValid)
            return BadRequest(ServiceResultExtension<List<Error>>.Failure(null, ModelState));

        User loggedUser = (await userServices.GetAll()).FirstOrDefault(u =>
            u.Username == tokenRequest.Username &&
            u.Password == tokenRequest.Password);

        if (loggedUser == null)
        {
            ModelState.AddModelError("Global", "Invalid username or password.");
            
            return Unauthorized(ServiceResultExtension<List<Error>>.Failure(null, ModelState));
        }

        TokenService tokenService = new TokenService();
        string token = tokenService.CreateToken(loggedUser);
        
        return Ok(new
        {
            token
        });
    }
}