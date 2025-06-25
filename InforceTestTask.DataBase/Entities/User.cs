using InforceTestTask.DataBase.Enums;
using Microsoft.EntityFrameworkCore;

namespace InforceTestTask.DataBase.Entities;

[PrimaryKey(nameof(Id))]
[Index(nameof(UserName), IsUnique = true)]
public record User
{
    public long Id { get; init; }

    public required string UserName { get; init; }

    public required string Password { get; init; }

    public UserType UserType { get; init; } = UserType.Ordinary;
}
