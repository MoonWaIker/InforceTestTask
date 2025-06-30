namespace InforceTestTask.Core.Models;

public abstract record UserCredentialsBase
{
    public virtual required string UserName { get; init; }

    public virtual required string Password { get; init; }
}
