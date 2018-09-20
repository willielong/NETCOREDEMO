using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Workflow.comm;
using System.Net.Http;
using Workflow.Dto.sys;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Workflow.Core.Config;
using Workflow.Core.Filter;

namespace Workflow.Core.Controllers
{
    [Authorize("CustomAuthorize")]
    [Route("api/[controller]/")]
    //AllowAnonymous]
    //[UserInfoFilter]
    public class ValuesController : BaseController
    {
        public ValuesController([FromServices]IMapper mapper)
        {

        }
        
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
