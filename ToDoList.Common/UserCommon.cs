using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Entities.Models;
using ToDoList.Entities.DTOs;

namespace ToDoList.Common
{
    public static class UserCommon
    {
        public static UserDTO UserToUserDTO(User user)
        {
            return new UserDTO
            {
                Id= user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                BirthdayDate = user.BirthdayDate,
                Email = user.Email,
                ToDos = user.ToDos
            };
        }

        public static User UserDTOToUser(UserDTO user)
        {
            return new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                BirthdayDate = user.BirthdayDate,
                Email = user.Email,
                ToDos = user.ToDos
            };
        }
    }
}
