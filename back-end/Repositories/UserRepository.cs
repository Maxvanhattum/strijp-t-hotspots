using Data.Context;
using DataTransferObjects;
using Models;
using Repositories.Base;
using System.Linq;

namespace Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DBContextApp dBContext) : base(dBContext)
        {
        }

        public User Create(UserCreateRequestDTO userCreateRequest)
        {
            User user = new User(userCreateRequest.Email, userCreateRequest.Password, userCreateRequest.Firstname, userCreateRequest.Lastname, userCreateRequest.Role);
            ts.Add(user);
            Save();
            return user;

        }

        public User GetByEmail(string email)
        {
            User user = ts.Where(b => b.Email == email).FirstOrDefault();
            return user;
        }
    }
}
