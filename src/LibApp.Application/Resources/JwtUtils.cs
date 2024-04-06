using LibApp.Application.Core.Services;
using LibApp.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LibApp.Application.Resources
{
    public interface IJwtUtils
    {
        public string GenerateJwtToken(Account account);
        public string? ValidateJwtToken(string? token);
    }
    public class JwtUtils : IJwtUtils
    {
        private readonly IConfiguration _config;
        private readonly ILoggerService _loggerService;
        public JwtUtils(IConfiguration config, ILoggerService loggerService)
        {
            _config = config;
            _loggerService = loggerService;
        }

        public string GenerateJwtToken(Account account)
        {
            // generate token that is valid for 15 minutes
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config.GetSection("Jwt:SigningKey").Value);
            var claims = new List<Claim>()
            {
                new Claim("sub", account.UserName),
                new Claim("name", account.UserName),
                new Claim("aud", _config.GetSection("Jwt:Audience").Value),
                new Claim("id", account.Id.ToString())
            };
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _config.GetSection("Jwt:Issuer").Value,
                Audience = _config.GetSection("Jwt:Audience").Value,
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        public string? ValidateJwtToken(string? token)
        {
            if (token == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config.GetSection("Jwt:SigningKey").Value);
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var accountId = jwtToken.Claims.First(x => x.Type == "id").Value;

                return accountId;
            }
            catch
            {
                return null;
            }
        }
    }
}
