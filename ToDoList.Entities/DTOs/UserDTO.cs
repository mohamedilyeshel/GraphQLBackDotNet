using HotChocolate;
using System.ComponentModel;
using ToDoList.Entities.Models;

namespace ToDoList.Entities.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public DateTime? BirthdayDate { get; set; }
        public List<ToDo> ToDos { get; set; }
    }
}
