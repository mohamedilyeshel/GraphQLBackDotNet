using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ToDoList.Common.CustomExceptions;
using ToDoList.Entities.Inputs;
using ToDoList.Web.Graphql.AuthModel;
using ToDoList.Common;
using ToDoList.DataAccess.Repositories;
using ToDoList.Common.CustomExceptions.ErrorFilter;

namespace ToDoList.Web.Graphql.Schema.Mutations
{
    public class Mutation
    {
        //[Error(typeof(AppException))]
        public async Task<string> Login(LoginInput loginInput, [Service] UserRepository userRepository, [Service] IOptions<TokenSettings> tokenSettings)
        {
            try
            {
                var userExist = await userRepository.UserExistLogin(loginInput);
                var token = CommonUtilities.GenerateJWT(userExist, tokenSettings.Value.Issuer, tokenSettings.Value.Audience, tokenSettings.Value.Key);
                return token;
            }
            catch (GraphQLException e)
            {
                throw new GraphQLException(new Error(e.Message, "NOT_EXIST"));
            }
        }

        [Error(typeof(AppException))]
        public async Task<string> Register(RegisterInput registerInput, [Service] UserRepository userRepository, [Service] IOptions<TokenSettings> tokenSettings)
        {
            try
            {
                await userRepository.UserRegister(registerInput);
                return "Your account is registered";
            }
            catch (Exception e)
            {
                throw new AppException(e.Message != null ? e.Message : "Server Error");
            }
        }
    }
}
