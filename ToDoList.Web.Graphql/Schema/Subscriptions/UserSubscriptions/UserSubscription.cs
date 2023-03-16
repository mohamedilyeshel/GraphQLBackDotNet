using ToDoList.Entities.DTOs;

namespace ToDoList.Web.Graphql.Schema.Subscriptions.UserSubscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    public class UserSubscription
    {
        [Subscribe]
        public UserDTO UserAdded([EventMessage] UserDTO user) => user;

        [Subscribe]
        public UserDTO UserDeleted([EventMessage] UserDTO response) => response;

        [Subscribe]
        public UserDTO UserUpdated([EventMessage] UserDTO response) => response;
    }
}
