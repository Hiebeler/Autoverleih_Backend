using Autoverleih_Backend.Db.Data;

namespace urlaubsplanungstool_backend.Common
{
    public interface IJwtService
    {
        string GenerateJwtToken(User user);
        string GenerateRefreshToken();
        User GetUserFromExpiredToken(string token);
    }
}