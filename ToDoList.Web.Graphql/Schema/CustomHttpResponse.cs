using HotChocolate.AspNetCore.Serialization;
using HotChocolate.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Common
{
    public class CustomHttpResponse : DefaultHttpResponseFormatter
    {
        public CustomHttpResponse(HttpResponseFormatterOptions options) : base(options)
        {

        }

        protected override HttpStatusCode OnDetermineStatusCode(
        IQueryResult result, FormatInfo format,
        HttpStatusCode? proposedStatusCode)
        {
            if (result.Errors?.Count > 0 &&
                result.Errors.Any(error => error.Code == "NOT_EXIST"))
            {
                return HttpStatusCode.BadRequest;
            }

            // In all other cases let Hot Chocolate figure out the
            // appropriate status code.
            return base.OnDetermineStatusCode(result, format, proposedStatusCode);
        }
    }
}
