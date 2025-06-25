using System.ComponentModel.DataAnnotations;
using InforceTestTask.DataBase.Enums;
using InforceTestTask.DataBase.Utils;
using Microsoft.EntityFrameworkCore;

namespace InforceTestTask.DataBase.Entities;

[PrimaryKey(nameof(Id))]
[Index(nameof(UserName), IsUnique = true)]
public record User
{
    public long Id { get; init; }

    [Required]
    [MinLength(StringConstants.MinLength)]
    [MaxLength(StringConstants.MaxLength)]
    public required string UserName { get; init; }

    [Required]
    [MinLength(StringConstants.MinLength)]
    [MaxLength(StringConstants.MaxLength)]
    public required string Password { get; init; }

    public UserType UserType { get; init; } = UserType.Ordinary;
}
