using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Entities.Models
{
    public class ToDo
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public bool IsDone { get; set; } = false;
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
