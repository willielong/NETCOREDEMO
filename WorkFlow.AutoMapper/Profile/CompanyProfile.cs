using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Workflow.Dto.business.Company;
using Workflow.Entity.Imp;
using Workflow.Entity.Imp.DataBase;
using WorkFlow.AutoMapper.EntityMapper;

namespace WorkFlow.AutoMapper
{
    public class CompanyProfile : Profile, ICommProfile
    {
        public CompanyProfile()
        {
            ///进行单位映射
            CreateMap<Company, Dto_Company>().BeforeMap((data, dto) => {              
                dto.dis_c_head = data.c_head;
            })
            .ForMember(o => o.dis_head, mo => mo.NullSubstitute(""));
            CreateMap<Dto_Company, Company>();
           
        }
    }
}
