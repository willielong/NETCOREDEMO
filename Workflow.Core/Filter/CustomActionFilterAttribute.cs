using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.comm;
using Workflow.Entity.Imp.DataBase;

namespace Workflow.Core.Config
{
    public class CustomActionFilterAttribute : Attribute, IActionFilter
    {
        public CustomActionFilterAttribute()
        {
           
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
         
        }
    }
}
