using System.ComponentModel.DataAnnotations;

namespace InforceTestTask.Abstractions.Models;

public abstract record ShortenUrlBase
{
    public Guid Id { get; init; }

    [Required]
    public required Uri OriginalUrl { get; init; }

    [Required]
    public required Uri FinalUrl { get; init; }

    [Required]
    public required DateTime CreatedDate { get; init; }

    [Required]
    public required Guid UserId { get; init; }
}
