using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.comm;
using Workflow.Entity.Imp.DataBase;

namespace Workflow.Core.Controllers
{
    public class BaseController : Controller
    {

        public IHttpContextAccessor httpContextAccessor { get; set; }
        public BaseController(IHttpContextAccessor _httpContextAccessor)
        {
            // httpContextAccessor = _httpContextAccessor;
            //httpContextAccessor.HttpContext.Session.SetString("User", HttpContext.User.Identity.Name);
            //var ss = HttpContext.User.Identity.Name;
            //ServiceLocator.readContext = new ReadDbContext();
            //ServiceLocator.writeContext = new WriteDbContext();
            //ServiceLocator.writeContext.Database.EnsureCreated();
        }

        ~BaseController()
        {
            //ServiceLocator.readContext.Dispose();
            //ServiceLocator.writeContext.Dispose();
        }
    }
}
