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

namespace Workflow.ServiceImp
{
    public class CompayServie : LogBase<CompayServie>, ICompanyService
    {
        private readonly ICompanyBusiness business;
        private readonly IMapper mapper;
        public CompayServie(ICompanyBusiness _business, IMapper _mapper)
        {
            if (business == null)
            {
                business = _business;
            }
            if (null == mapper) mapper = _mapper;
        }
        /// <summary>
        /// 获取多个数据
        /// </summary>
        /// <returns></returns>
        public List<Dto_Company> Get()
        {
            Error("错误信息01", "Get");
            List<Company> co = new List<Company>();
            co.Add(new Company() { ognName = "0001", ognId = "01", c_head = "111", head = "123", parentId = "0" });
            co.Add(new Company() { ognName = "0002", ognId = "02", c_head = "111", head = "123", parentId = "0" });
            List<Dto_Company> dtos;
            co.ToDtos(out dtos, mapper);
            return dtos;
            // throw new NotImplementedException();
        }

        /// <summary>
        /// 获取单个数据
        /// </summary>
        /// <returns></returns>
        public Dto_Company Single()
        {
            Error("错误信息01", "Single");
            Dto_Company co;
            business.Single().ToDto(out co, mapper);
            return co;
        }
    }
}
