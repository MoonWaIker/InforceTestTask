using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace InforceTestTask.DataBase.Entities;

public sealed class User : IdentityUser<Guid>
{
    [ForeignKey(nameof(ShortenUrlEntity.UserId))]
    public ICollection<ShortenUrlEntity> ShortenUrls { get; init; } = new List<ShortenUrlEntity>();
}
