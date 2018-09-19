using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workflow.Core.Config
{
    public class UserInfoFilterAttribute : Attribute, IActionFilter
    {
        public UserInfoFilterAttribute()
        {
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var ss = context.HttpContext.Request.Headers;
            throw new NotImplementedException();
        }
    }
}
