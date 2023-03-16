using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Entities.Models;
using ToDoList.Entities.DTOs;

namespace ToDoList.Common
{
    public static class ToDoCommon
    {
        public static ToDoDTO ToDo_To_ToDoDTO(ToDo todo)
        {
            return new ToDoDTO
            {
                Id = todo.Id,
                Content = todo.Content,
                IsDone = todo.IsDone,
                User = todo.User,
            };
        }

        public static ToDo ToDoDTO_To_ToDo(ToDoDTO todo)
        {
            return new ToDo
            {
                Content = todo.Content,
                IsDone = todo.IsDone,
                UserId = todo.UserId,
                User = todo.User,
            };
        }
    }
}
