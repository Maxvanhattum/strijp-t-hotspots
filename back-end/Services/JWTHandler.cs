using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Models;
using Services.Interfaces;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Services
{
    public class JWTHandler : IJWTHandler
    {
        private string key;
        private string issuer;

        public JWTHandler(IConfiguration configuration)
        {
            this.key = configuration["App:JWT:Key"];
            this.issuer = configuration["App:JWT:Issuer"];
        }

        public string GenerateToken(User employeeLoggedIn, string rememberMe)
        {

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, employeeLoggedIn.Email),
                new Claim(ClaimTypes.Role, employeeLoggedIn.Role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            DateTime expiry;
            if (rememberMe == "true")
            {
                expiry = DateTime.Now.AddDays(30);
            }
            else
            {
                expiry = DateTime.Now.AddDays(1);
            }
            var token = new JwtSecurityToken(issuer, issuer, claims, expires: expiry, signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GetClaim(string token, string claimName)
        {
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            JwtSecurityToken securityToken = jwtSecurityTokenHandler.ReadJwtToken(token);
            return securityToken.Claims.First(claim => claim.Type == claimName).Value;
        }

    }
}
