using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Workflow.comm;
using Workflow.Core.Config;
using Workflow.Dto.business.Company;
using Workflow.Entity.Imp.DataBase;
using WorkFolw.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Workflow.Core.Controllers
{
    [ CustomActionFilter, Route("api/[controller]")]
    public class CompanyController : Controller
    {
        private ICompanyService _service;
        public CompanyController(ICompanyService service)
        {
            ServiceLocator.Ip = "127.0.0.1";
            ServiceLocator.currentUser = "Author";
            _service = service;
        }
        [HttpGet, Route("co")]
        public IActionResult GetCo()
        {
            // LogBase<CompanyController>.Error("错误信息01", "GetCo");
            return _service.Get().ToJsonResult();
        }
        [HttpGet, Route("single")]
        public IActionResult Single()
        {
            //LogBase<CompanyController>.Error("错误信息Single", "Single");
            return _service.Single().ToJsonResult();
        }
    }
}
