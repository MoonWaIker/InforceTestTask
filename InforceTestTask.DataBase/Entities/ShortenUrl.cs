using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace InforceTestTask.DataBase.Entities;

[PrimaryKey(nameof(Id))]
[Index(nameof(OriginalUrl), IsUnique = true)]
[Index(nameof(ShortenedUrl), IsUnique = true)]
public record ShortenUrl
{
    public int Id { get; init; }

    [Required]
    public required Uri OriginalUrl { get; init; }

    [Required]
    public required Uri ShortenedUrl { get; init; }
}
