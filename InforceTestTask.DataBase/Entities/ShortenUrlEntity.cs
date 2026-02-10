using System.ComponentModel.DataAnnotations.Schema;
using InforceTestTask.Abstractions.Models;
using Microsoft.EntityFrameworkCore;

namespace InforceTestTask.DataBase.Entities;

[PrimaryKey(nameof(Id))]
[Index(nameof(OriginalUrl), IsUnique = true)]
[Index(nameof(FinalUrl), IsUnique = true)]
public sealed record ShortenUrlEntity : ShortenUrlBase
{
    [ForeignKey(nameof(UserId))]
    public User? User { get; set; }
}
