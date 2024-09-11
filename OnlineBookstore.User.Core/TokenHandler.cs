using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace OnlineBookStore.User.Core
{
    public class TokenHandler : ITokenHandler
    {
        private readonly IConfiguration configuration;

        public TokenHandler(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public Task<string> CreateToker(UserRM user)
        {
            // Create Claims (information contain in token)
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.Name));
            claims.Add(new Claim(ClaimTypes.Email, user.Email));

            // Loop into roles of users (user have multipal role for using get(read) or post(write) )
            user.Roles.ForEach((role) =>
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            });

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15), // Time to expire token
                signingCredentials: credentials);

            return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}
