using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Entities.Models;

namespace ToDoList.Entities.Inputs
{
    public class ToDoAddInput
    {
        public string? Content { get; set; }
        public int UserId { get; set; }
    }
}
