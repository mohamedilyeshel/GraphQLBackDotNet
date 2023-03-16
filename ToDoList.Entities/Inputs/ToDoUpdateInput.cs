using HotChocolate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Entities.Models;

namespace ToDoList.Entities.Inputs
{
    public class ToDoUpdateInput
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public bool IsDone { get; set; }
        [DefaultValue(-1)]
        public Optional<int> UserId { get; set; }
    }
}
