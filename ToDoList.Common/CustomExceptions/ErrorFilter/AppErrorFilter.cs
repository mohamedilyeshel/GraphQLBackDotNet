using HotChocolate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Common.CustomExceptions.ErrorFilter
{
    public class AppErrorFilter : IErrorFilter
    {
        public IError OnError(IError error)
        {
            if(error.Exception == null)
            {
                return error.WithMessage("Server Error").RemoveLocations().RemoveExtensions();
            }
            return error.WithMessage(error.Exception.Message).RemoveLocations().RemoveExtensions();
        }
    }
}
