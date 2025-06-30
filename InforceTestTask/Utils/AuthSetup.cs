using Microsoft.AspNetCore.Authentication.Cookies;

namespace InforceTestTask.Utils;

public static class AuthSetup
{
    private const string CookieSettings = "CookieSettings";

    public static void ConfigureAuth(this WebApplicationBuilder builder)
    {
        builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
        options => builder.Configuration.Bind(CookieSettings, options));
    }
}
