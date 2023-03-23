using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using ToDoList.Entities.Models;

namespace ToDoList.Common
{
    public static class CommonUtilities
    {
        public static string GenerateJWT(User user, string issuer, string audience, string key)
        {
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtToken = new JwtSecurityToken(
                claims: new[] {
                        new Claim("Id", $"{user.Id}"),
                        new Claim("Email", $"{user.Email}"),
                        new Claim("FirstName", $"{user.FirstName}"),
                    // new Claim(ClaimTypes.Role, userExist.Role),
                },
                issuer: issuer,
                audience: audience,
                expires: DateTime.Now.AddDays(5),
                signingCredentials: credentials
            );

            string token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return token;
        }
    }
}
