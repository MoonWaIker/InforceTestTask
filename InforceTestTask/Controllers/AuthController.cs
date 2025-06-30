using InforceTestTask.Infrastructure.DTOs;
using InforceTestTask.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InforceTestTask.Controllers;

[ApiController]
[Authorize]
[Route(ControllerRoute)]
public class AuthController(IUserService service) : ControllerBase
{
    private const string ControllerRoute = "api/[controller]";

    [AllowAnonymous]
    public void Register()
    { }

    [AllowAnonymous]
    public IActionResult Login([FromBody] UserCredentialsDto userCredentials)
    {
        if (!service.AreCredentialsCorrect(userCredentials))
        {
            return Unauthorized();
        }

        throw new NotImplementedException();
    }

    public void Logout()
    { }
}
