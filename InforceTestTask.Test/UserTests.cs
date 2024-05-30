using InforceTestTask.Enums;
using InforceTestTask.Models;

namespace InforceTestTask.Test;

public sealed class UserTests
{
    public static IEnumerable<object[]> UserData =>
    [
        [
            new User { Id = 1, UserName = "test", Password = "password", Role = Role.Admin },
            new User { UserName = "test", Password = "password" },
            true
        ],
        [
            new User { UserName = "test", Password = "password" },
            new User { UserName = "test2", Password = "password2" },
            false
        ]
    ];

    [Theory]
    [MemberData(nameof(UserData))]
    public void Equals_ReturnsExpectedResult(User user1, User user2, bool expected)
    {
        Assert.Equal(expected, user1.Equals(user2));
    }

    [Theory]
    [MemberData(nameof(UserData))]
    public void GetHashCode_ReturnsExpectedResult(User user1, User user2, bool expected)
    {
        Assert.Equal(expected, user1.GetHashCode() == user2.GetHashCode());
    }

    [Theory]
    [MemberData(nameof(UserData))]
    public void EqualityOperator_ReturnsExpectedResult(User user1, User user2, bool expected)
    {
        Assert.Equal(expected, user1 == user2);
    }

    [Theory]
    [MemberData(nameof(UserData))]
    public void InequalityOperator_ReturnsExpectedResult(User user1, User user2, bool expected)
    {
        Assert.NotEqual(expected, user1 != user2);
    }
}