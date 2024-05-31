using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InforceTestTask.Utils;

namespace InforceTestTask.Models;

[Table("ShortUrl")]
public sealed class ShortUrlView
{
    public int Id { get; init; }

    [ForeignKey(nameof(User.Id))] public int CreatorId { get; set; }

    [MaxLength(Constants.MaxUrlLength)] public required string Url { get; init; }

    [MaxLength(Constants.MaxUrlLength)] public required string ShortUrl { get; set; }
}