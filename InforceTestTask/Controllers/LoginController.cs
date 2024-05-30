using System.Security.Claims;
using InforceTestTask.Context;
using InforceTestTask.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InforceTestTask.Controllers;

[ApiController]
[Route("[Controller]")]
public sealed class LoginController(InforceDbContext context) : Controller
{
    private const string DefaultAuthType = "ApplicationCookie";

    [AllowAnonymous]
    [HttpPost("[action]")]
    public async Task<IActionResult> Login(User model)
    {
        if (ModelState.IsValid && context.Users
                .AsEnumerable()
                .Contains(model))
            return await Authenticate(model);

        return Unauthorized();
    }

    [AllowAnonymous]
    [HttpPost("[action]")]
    public async Task<IActionResult> Register(User model)
    {
        if (!ModelState.IsValid || context.Users
                .AsEnumerable()
                .Any(u => u.UserName == model.UserName))
            return BadRequest();

        context.Users.Add(model);
        await context.SaveChangesAsync();

        return await Authenticate(model);
    }

    [Authorize]
    [HttpPost("[action]")]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        return Ok();
    }

    [NonAction]
    private async Task<IActionResult> Authenticate(User user)
    {
        var claim = new Claim[]
        {
            new(ClaimsIdentity.DefaultNameClaimType, user.UserName),
            new(ClaimsIdentity.DefaultRoleClaimType, user.Role.ToString())
        };
        ClaimsIdentity claimsIdentity = new(claim, DefaultAuthType,
            ClaimsIdentity.DefaultNameClaimType,
            ClaimsIdentity.DefaultRoleClaimType);

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity));

        return Ok();
    }
}