using System.Data;
using InforceTestTask.Context;
using InforceTestTask.Services.Interfaces;

namespace InforceTestTask.Services;

public sealed class ShortUrlGenerator(IHttpContextAccessor httpContextAccessor, InforceDbContext context)
    : IShortUrlGenerator
{
    private const string Chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
    private static readonly int Base = Chars.Length;

    private readonly string _root = httpContextAccessor.HttpContext?.Request.Host.Value
                                    ?? throw new NoNullAllowedException();

    public string GenerateShortUrl(string url)
    {
        var number = context.ShortUrlViews.Count() + 1;

        var s = string.Empty;
        while (number > 0)
        {
            s += Chars[number % Base];
            number /= Base;
        }

        return _root + "/" + string.Join(string.Empty, s.Reverse());
    }
}