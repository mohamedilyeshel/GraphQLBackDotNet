using ToDoList.Common.CustomExceptions;
using ToDoList.DataAccess.Repositories;
using ToDoList.Entities.Inputs;
using ToDoList.Entities.Models;

namespace ToDoList.Web.Graphql.Schema.Mutations
{
    [ExtendObjectType(typeof(Mutation))]
    public class ToDoMutation
    {
        [Error(typeof(AppException))]
        public async Task<ToDo> AddToDo(ToDoAddInput todo, [Service] ToDoRepository toDoRepository)
        {
            var newToDo = await toDoRepository.AddToDo(todo);
            return newToDo;
        }

        [Error(typeof(AppException))]
        public async Task<string> UpdateToDo(ToDoUpdateInput todo, [Service] ToDoRepository toDoRepository)
        {
            var response = await toDoRepository.UpdateToDo(todo);
            return response;
        }

        [Error(typeof(AppException))]
        public async Task<string> DeleteToDo(int id, [Service] ToDoRepository toDoRepository)
        {
            var response = await toDoRepository.DeleteToDo(id);
            return response;
        }
    }
}
