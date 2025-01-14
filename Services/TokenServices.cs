using AppAPI.Entities;
using AppAPI.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AppAPI.Services
{
    public class TokenServices(IConfiguration configuration) : ITokenServices
    {


        public string CreateToken(AppUser user)
        {
            var tokenKey = configuration["TokenKey"]?? throw new Exception("cannot access tokenKey from appsettings");
            if (tokenKey.Length < 64)
            {
                throw new Exception("Your tokenKey needs to be longer");
            }
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));

            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier,user.UserName)
            };
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials=creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }
    }
}
