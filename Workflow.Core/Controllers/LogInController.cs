using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workflow.comm;

namespace Workflow.Core.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]"),Route("api/[controller]")]
    [ApiVersion("1.0")]
    [ApiVersion("3.0")]
    public class LogInController : Controller
    {
        [HttpPost]
        public IActionResult Post([FromBody]UserModel user)
        {
            var tpm = new TokenBusiness();
            var token = tpm.GenerateToken(HttpContext, user.userName, "").Result;
            if (null != token)
            {
                return new JsonResult(token);
            }
            else
            {
                return NotFound();
            }

        }
    }
    public class UserModel
    {
        public string userName { get; set; }
        public string pwd { get; set; }
    }
}