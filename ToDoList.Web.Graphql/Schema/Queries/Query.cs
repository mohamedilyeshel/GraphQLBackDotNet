using ToDoList.DataAccess.Repositories;
using ToDoList.Entities.Models;
using ToDoList.Web.Graphql.DataLoaders;

namespace ToDoList.DataAccess.Schema.Queries
{
    public class Query
    {
        [UsePaging]
        [UseProjection]
        [UseFiltering]
        public IQueryable<User> GetUsers([Service] UserRepository userRepository)
        {
            var users = userRepository.GetUsers();
            return users;
        }

        public async Task<User?> GetUser(int id, [Service] UserBatchDataLoader userBatchDataLoader)
        {
            var user = await userBatchDataLoader.LoadAsync(id);
            return user;
        }

        [UsePaging]
        [UseProjection]
        [UseFiltering]
        public IQueryable<ToDo> GetToDos([Service] ToDoRepository toDoRepository)
        {
            return toDoRepository.GetToDos();
        }

        public async Task<ToDo?> GetToDo(int id, [Service] ToDoRepository toDoRepository)
        {
            var todo = await toDoRepository.GetToDo(id);
            return todo;
        }
    }
}
