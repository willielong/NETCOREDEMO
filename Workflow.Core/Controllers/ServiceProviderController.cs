using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Workflow.comm;
using Workflow.Entity.Imp;
using Workflow.ServiceImp;
using WorkFolw.Service;

namespace Workflow.Core.Controllers
{
    [Produces("application/json")]
    [Authorize("CustomAuthorize")]
    [Route("api/v{version:apiVersion}/sp"), Route("api/sp/")]
    [ApiVersion("1.0")]
    [ApiVersion("3.0")]
    public class ServiceProviderController : Controller
    {
        public IServiceProvider serviceProvider;
        private IServiceProviderServices serviceProviderServices;
        public ServiceProviderController(IServiceProvider _serviceProvider)
        {
            serviceProvider = _serviceProvider;
            serviceProviderServices = _serviceProvider.GetService<IServiceProviderServices>();
        }

        [HttpGet, Route("o1")]
        public IActionResult get()
        {
            return "".ToJsonResult();
        }
    }
}