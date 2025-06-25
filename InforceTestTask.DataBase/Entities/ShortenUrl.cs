using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using Microsoft.EntityFrameworkCore;

namespace InforceTestTask.DataBase.Entities;

[PrimaryKey(nameof(Id))]
[Index(nameof(OriginalUrl), IsUnique = true)]
[Index(nameof(UrlHash), IsUnique = true)]
public record ShortenUrl
{
    public BigInteger Id { get; init; }

    [Required]
    public required Uri OriginalUrl { get; init; }

    [Required]
    public required int UrlHash { get; init; }

    public DateTime CreatedDate { get; init; }

    public long UserId { get; init; }

    [ForeignKey(nameof(UserId))]
    public required User User { get; init; }
}
