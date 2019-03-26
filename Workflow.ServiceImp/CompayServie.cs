using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Dto.business.Company;
using Workflow.Entity.Imp;
using WorkFolw.Service;
using WorkFlow.AutoMapper.EntityMapper;
using AutoMapper;
using Workflow.Entity.Imp.DataBase;
using Microsoft.Extensions.DependencyInjection;
using WorkFlow.Business.Company;
using Workflow.comm;
using Workflow.Dto.sys;
using Microsoft.AspNetCore.Http;

namespace Workflow.ServiceImp
{
    public class CompayServie : LogBase<CompayServie>, ICompanyService
    {
        public ICompanyBusiness business { get; set; }
        private readonly IMapper mapper;
        private IHttpContextAccessor httpContextAccessor;
        public CompayServie(ICompanyBusiness _business, IMapper _mapper, IHttpContextAccessor _httpContextAccessor)
        {
            if (business == null)
            {
                business = _business;
            }
            if (null == mapper) { mapper = _mapper; }
            if (null == httpContextAccessor)
            { httpContextAccessor = _httpContextAccessor; }
        }
        /// <summary>
        /// 获取多个数据
        /// </summary>
        /// <returns></returns>
        public List<Dto_Company> Get()
        {
            Error("错误信息01", "Get");
            List<Company> co = business.All();
         
            List<Dto_Company> dtos;
            co.ToDtos(out dtos, mapper);
            return dtos;
            // throw new NotImplementedException();
        }

        /// <summary>
        /// 获取单个数据
        /// </summary>
        /// <returns></returns>
        public IResponseMessage Single()
        {
            
            Error("错误信息01", "Single");
            Dto_Company co;
            var ss = httpContextAccessor.HttpContext.Session.GetString("user");
            business.Single().ToDto(out co, mapper);
            return co.ToResponse();
        }

        /// <summary>
        /// 获取所有的公司信息
        /// </summary>
        /// <returns></returns>
        public List<Dto_Company>All()
        {
            List<Company> co = business.All();
            List<Dto_Company> dtos;
            co.ToDtos(out dtos, mapper);
            return dtos;
        }

        /// <summary>
        /// 获取当前公司所有数据
        /// </summary>
        /// <returns></returns>
        public object own()
        {
            return business.own();
        }
    }
}
