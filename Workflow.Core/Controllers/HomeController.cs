using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workflow.Core.Config;

namespace Workflow.Core.Controllers
{
    [CustomActionFilter]
    public class HomeController : BaseController
    {
        public HomeController(IHttpContextAccessor httpContextAccessor) : base(_httpContextAccessor: httpContextAccessor) { }
        public IActionResult Index()
        {
            return View();
        }
    }
}