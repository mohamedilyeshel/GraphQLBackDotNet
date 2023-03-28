using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using ToDoList.Entities.Models;
using ToDoList.Common.GenericResponses;

namespace ToDoList.Common
{
    public enum Codes
    {
        BAD_REQUEST = 0,
        UNAUTHORIZED = 1,
        FORBIDDEN = 2,
        NOT_FOUND = 3,
        NOT_ACCEPTABLE = 4,
        SERVER_ERROR = 5
    }

    public static class CommonUtilities
    {
        private static Codes errorCodes;

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

        public static int GenerateStatusCode(string Code = "5")
        {
            int code = int.Parse(Code);
            return code switch
            {
                (int)Codes.BAD_REQUEST => 400,
                (int)Codes.UNAUTHORIZED => 401,
                (int)Codes.NOT_FOUND => 404,
                (int)Codes.NOT_ACCEPTABLE => 406,
                (int)Codes.FORBIDDEN => 403,
                _ => 500,
            };
        }

        public static ResponseService<T> GenerateErrorReponse<T>(string ErrorCode = "5", string ErrorMessage = "Server Error")
        {
            ResponseService<T> response = new ResponseService<T>();
            response.Success = false;
            response.Data = default(T);
            response.statusCode = GenerateStatusCode(ErrorCode ?? "5");
            response.Errors = new ErrorResponse { Message = ErrorMessage };
            return response;
        }
    }
}
