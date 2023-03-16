using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Entities.Models
{
    public class User
    {
        public User() 
        {
            ToDos= new List<ToDo>();
        }
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public DateTime? BirthdayDate { get; set; }
        public List<ToDo> ToDos { get; set; }
    }
}
