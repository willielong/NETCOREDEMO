using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Workflow.comm;
using Workflow.Dto.business.Company;
using Workflow.Entity.Imp;

namespace WorkFlow.AutoMapper.EntityMapper
{
    public static class Map_Company
    {
        public static void ToDtoList(this List<Company> buModel,out List<Dto_Company> data)
        {
             data = ServiceLocator.mapper.Map<List<Company>, List<Dto_Company>>(buModel);           
        }
        public static void ToDto(this Company buModel, out Dto_Company data)
        {
            //new CommProfile();
             data = ServiceLocator.mapper.Map<Dto_Company>(buModel);
        }

        public static void ToDtos(this List<Company> buModel, out List<Dto_Company> dtos)
        {
            dtos = ServiceLocator.mapper.Map<List<Company>, List<Dto_Company>>(buModel);
        }
    }
}
