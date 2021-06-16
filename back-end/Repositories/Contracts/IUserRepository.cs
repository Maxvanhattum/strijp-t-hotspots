using DataTransferObjects;
using Models;

namespace Repositories
{
    public interface IUserRepository
    {
        User GetByEmail(string email);
        User Create(UserCreateRequestDTO userCreateRequest);
    }
}
