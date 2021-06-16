using Models;

namespace Services.Interfaces
{
    public interface IJWTHandler
    {
        string GenerateToken(User userLoggedIn, string rememberMe);
        string GetClaim(string token, string claimName);

    }
}
