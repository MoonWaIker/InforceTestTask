using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

    public DateTime CreatedDate { get; init; } = DateTimeOffset.UtcNow.UtcDateTime;

    public long UserId { get; init; }

    [ForeignKey(nameof(UserId))]
    public required User User { get; init; }
}
