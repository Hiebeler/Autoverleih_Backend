using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Autoverleih_Backend.Db.Data;
using Microsoft.IdentityModel.Tokens;

namespace urlaubsplanungstool_backend.Common
{
    public class JwtService : IJwtService
    {
        private const int EXPIRATION_MINUTES = 14400;

        private readonly string jwtKey;
        private readonly string jwtAudience;
        private readonly string jwtIssuer;

        public JwtService(IConfiguration configuration)
        {
            jwtAudience = configuration["Jwt:Audience"]!;
            jwtIssuer = configuration["Jwt:Issuer"]!;
            jwtKey = configuration["Jwt:Key"]!;
        }
        
        public JwtService(string key, string issuer, string audience)
        {
            jwtAudience = audience;
            jwtIssuer = issuer;
            jwtKey = key;
        }

        public string GenerateJwtToken(User user)
        {
            var expiration = DateTime.UtcNow.AddMinutes(EXPIRATION_MINUTES);

            var token = CreateJwtToken(
                CreateClaims(user),
                CreateSigningCredentials(),
                expiration
            );

            var tokenHandler = new JwtSecurityTokenHandler();


            return tokenHandler.WriteToken(token);
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        public User GetUserFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false, //you might want to validate the audience and issuer depending on your use case
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),
                ValidateLifetime = false //here we are saying that we don't care about the token's expiration date
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                    StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");
            var claims = principal.Claims;
            var user = new User
            {
                Id = int.Parse(claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value),
                Username = claims.First(c => c.Type == ClaimTypes.Name).Value,
            };
            return user;
        }

        private JwtSecurityToken CreateJwtToken(List<Claim> claims, SigningCredentials credentials,
            DateTime expiration)
        {
            return new JwtSecurityToken(
                jwtIssuer,
                jwtAudience,
                claims,
                expires: expiration,
                signingCredentials: credentials
            );
        }

        private List<Claim> CreateClaims(User user)
        {
            try
            {
                var claims = new List<Claim>
                {
                    new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new(ClaimTypes.Name, user.Username)
                };
                return claims;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        private SigningCredentials CreateSigningCredentials()
        {
            return new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwtKey)
                ),
                SecurityAlgorithms.HmacSha256
            );
        }
    }
}