using HotChocolate.Authorization;
using HotChocolate.Subscriptions;
using Microsoft.EntityFrameworkCore;
using ToDoList.Common;
using ToDoList.Common.CustomExceptions;
using ToDoList.DataAccess.Repositories;
using ToDoList.Entities.Inputs;
using ToDoList.Entities.Models;

namespace ToDoList.Web.Graphql.Schema.Mutations
{
    [ExtendObjectType(typeof(Mutation))]
    public class UserMutation
    {
        [Authorize]
        [Error(typeof(AppException))]
        public async Task<User> AddUser(UserAddInput user, [Service] UserRepository userRepository, [Service] ITopicEventSender sender)
        {
            var newUser = await userRepository.AddUser(user);
            await sender.SendAsync(nameof(Subscriptions.UserSubscriptions.UserSubscription.UserAdded), UserCommon.UserToUserDTO(newUser));
            return newUser;
        }

        [Error(typeof(AppException))]
        public async Task<User> UpdateUser(UserUpdateInput user, [Service] UserRepository userRepository, [Service] ITopicEventSender sender)
        {
            var userUpdated = await userRepository.UpdateUser(user);
            await sender.SendAsync(nameof(Subscriptions.UserSubscriptions.UserSubscription.UserUpdated), UserCommon.UserToUserDTO(userUpdated));
            return userUpdated;
        }

        [Error(typeof(AppException))]
        public async Task<User> DeleteUser(int id, [Service] UserRepository userRepository, [Service] ITopicEventSender sender)
        {
            var userDeleted = await userRepository.DeleteUser(id);
            await sender.SendAsync(nameof(Subscriptions.UserSubscriptions.UserSubscription.UserDeleted), UserCommon.UserToUserDTO(userDeleted));
            return userDeleted;
        }
    }
}
