using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace InforceTestTask.DataBase.Entities;

// TODO Figure out what does it show for clients in order to create abstract record for DTO and entity
[PrimaryKey(nameof(Id))]
[Index(nameof(OriginalUrl), IsUnique = true)]
[Index(nameof(UrlHash), IsUnique = true)]
public sealed record ShortenUrl
{
    public Guid Id { get; init; }

    [Required]
    public required Uri OriginalUrl { get; init; }

    [Required]
    public required int UrlHash { get; init; }

    public DateTime CreatedDate { get; init; }

    public required Guid UserId { get; init; }

    [ForeignKey(nameof(UserId))]
    public User? User { get; init; }
}
