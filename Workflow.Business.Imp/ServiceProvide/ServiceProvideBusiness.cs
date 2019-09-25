using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Entity;
using Workflow.Repository;
using WorkFlow.Business.ServiceProvide;
using Microsoft.Extensions.DependencyInjection;

namespace Workflow.Business.Imp.ServiceProvide
{
    using Workflow.comm;
    using Workflow.Entity.Imp;

    public class ServiceProvideBusiness : IServiceProvideBusiness
    {
        #region 构造函数
        private IWriteRepository<Workbench> writeRepository;
        private readonly IReadRepository<Workbench> readRepository;
        private IHttpContextAccessor httpContextAccessor;
        //private WriteBehavior writeBehavior;
        //private ReadBehavior readBehavior;
        public ServiceProvideBusiness(IServiceProvider _serviceProvider)
        {
            if (null == writeRepository)
                writeRepository = _serviceProvider.GetService<IWriteRepository<Workbench>>();
            if (null == readRepository)
                readRepository = _serviceProvider.GetService<IReadRepository<Workbench>>();
            if (null == httpContextAccessor)
                httpContextAccessor = _serviceProvider.GetService<IHttpContextAccessor>();
            //if (null == writeBehavior)
            //    writeBehavior = new WriteBehavior(writeRepository);
            //if (null == readBehavior)
            //    readBehavior = new ReadBehavior(readRepository);
        }
               
        #endregion
    }
}
