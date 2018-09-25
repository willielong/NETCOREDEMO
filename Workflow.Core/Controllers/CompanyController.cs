﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    /// <summary>
    /// 获取单位的单元
    /// </summary>
    [Authorize("CustomAuthorize"), CustomActionFilter, Route("api/v{version:apiVersion}/[controller]"), Route("api/[controller]")]
    [ApiVersion("1.0")]
    [ApiVersion("3.0")]
    public class CompanyController : BaseController
    {
        private ICompanyService _service;
        public CompanyController(ICompanyService service)
        {
            ServiceLocator.Ip = "127.0.0.1";
            ServiceLocator.currentUser = "Author";
            _service = service;
        }
        /// <summary>
        /// 进行数据加载的接口
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("co")]
        public IActionResult GetCo()
        {
            // LogBase<CompanyController>.Error("错误信息01", "GetCo");
            return _service.Get().ToJsonResult();
        }

        /// <summary>
        /// 进行单个数据加载
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("single")]
        public IActionResult Single()
        {
            //LogBase<CompanyController>.Error("错误信息Single", "Single");
            return _service.Single().ToJsonResult();
        }
    }
}
