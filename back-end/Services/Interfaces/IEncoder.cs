using Models;

namespace Services.Interfaces
{
    public interface IEncoder
    {
        bool ComparePassword(User userToVerify, string rawPassword);
        string HashPassword(string rawPassword);

    }
}
