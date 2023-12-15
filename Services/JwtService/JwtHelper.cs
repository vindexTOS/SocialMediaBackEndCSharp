using Auth.API.Infrastructure.Auth.JWT;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

 namespace Auth.JWT;

    public static class JWTHelper
    {
        public static string GenerateSecurityToken(string userName, int Id,string Role, IOptions<JWTConfiguration> options)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

           var key = Encoding.ASCII.GetBytes("AGFASGASGAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaazxczxczxczxczxczxczxczx412412412aaaaaaaaaaaaaSG");


            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, userName),
                    new Claim("UserId", Id.ToString()),
                    new Claim(ClaimTypes.Role, Role),
                }),
                Expires = DateTime.UtcNow.AddMinutes(60),
                Audience = "localhost",
                Issuer = "localhost",
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            //var identity = new ClaimsIdentity();
            //identity.AddClaim(new Claim("UserId", Id.ToString())); // we need userid for getall todos method
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
         }


    }

