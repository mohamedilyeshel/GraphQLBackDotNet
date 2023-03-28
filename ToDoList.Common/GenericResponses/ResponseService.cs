using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Common.GenericResponses
{
    public class ResponseService<T>
    {
        public int statusCode { get; set; } = 200;
        public bool Success { get; set; } = true;
        public T? Data { get; set; }
        public ErrorResponse? Errors { get; set; } = null;
    }
}
