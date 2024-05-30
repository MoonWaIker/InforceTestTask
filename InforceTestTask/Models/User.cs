using System.ComponentModel.DataAnnotations;
using InforceTestTask.Enums;

namespace InforceTestTask.Models;

public sealed class User : IEquatable<User>, IEqualityComparer<User>
{
    public int Id { get; init; }

    [MaxLength(short.MaxValue)] public required string UserName { get; init; }

    [MaxLength(short.MaxValue)] public required string Password { get; init; }

    public Role Role { get; init; }

    public bool Equals(User? x, User? y)
    {
        return x is not null && x.Equals(y);
    }

    public int GetHashCode(User obj)
    {
        return obj.GetHashCode();
    }

    public bool Equals(User? obj)
    {
        return obj is not null && UserName == obj.UserName && Password == obj.Password;
    }

    public static bool operator ==(User obj1, User obj2)
    {
        return obj1.Equals(obj2);
    }

    public static bool operator !=(User obj1, User obj2)
    {
        return !(obj1 == obj2);
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as User);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(UserName, Password);
    }
}