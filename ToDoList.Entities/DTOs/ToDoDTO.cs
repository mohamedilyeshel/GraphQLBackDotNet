using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Entities.Models;

namespace ToDoList.Entities.DTOs
{
    public class ToDoDTO
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public bool IsDone { get; set; } = false;
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
