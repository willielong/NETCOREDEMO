using System;
using System.Collections.Generic;
using System.Text;

using Workflow.Business.Imp.Company;
using WorkFlow.Business.Company;
using Workflow.comm;
using WorkFolw.Service;
using Microsoft.Extensions.DependencyInjection;
using Workflow.Entity.Imp.DataBase;
using Workflow.Dto.business.Company;
using Workflow.Dto.sys;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Workflow.Entity.Imp;
using WorkFlow.AutoMapper.EntityMapper;
using WorkFlow.Business.ServiceProvide;

namespace Workflow.ServiceImp
{

    public class ServiceProviderServices : LogBase<CompayServie>, IServiceProviderServices
    {
        private readonly IMapper mapper;
        private IHttpContextAccessor httpContextAccessor;
        private IServiceProvideBusiness business;
        public ServiceProviderServices(IServiceProvider _serviceProvider)
        {
            business = _serviceProvider.GetService<IServiceProvideBusiness>();
            httpContextAccessor = _serviceProvider.GetService<IHttpContextAccessor>();
            mapper = _serviceProvider.GetService<IMapper>();
        }
        
    }
}
