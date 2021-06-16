using DataTransferObjects;
using Models;

namespace Services.Interfaces
{
    public interface IAuthenticationHandler
    {
        User CreateUser(UserCreateRequestDTO createDTO);
        string LoginUser(UserLoginRequestDTO loginDTO);

    }
}
