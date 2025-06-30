using InforceTestTask.Infrastructure.DTOs;

namespace InforceTestTask.Infrastructure.Interfaces;

public interface IUserService
{
    void AddUser(UserCredentialsDto userCredentials);

    bool AreCredentialsCorrect(UserCredentialsDto userCredentials);
}
