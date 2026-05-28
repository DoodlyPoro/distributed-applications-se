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

        User? loggedUser = (await userServices.GetAll((u =>
            u.Username == tokenRequest.Username))).FirstOrDefault();
        
        Console.WriteLine($"LOGIN USERNAME: {tokenRequest.Username}");
        Console.WriteLine($"LOGIN PASSWORD: {tokenRequest.Password}");
        Console.WriteLine($"DB USER FOUND: {loggedUser != null}");
        Console.WriteLine($"DB HASH: {loggedUser?.Password}");

        if (loggedUser == null || !BCrypt.Net.BCrypt.Verify(tokenRequest.Password, loggedUser.Password))
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