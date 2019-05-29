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
        public static void ToDtoList(this List<Company> buModel, out List<Dto_Company> data, IMapper mapper)
        {
            data = mapper.Map<List<Company>, List<Dto_Company>>(buModel);
        }
        public static void ToDto(this Company buModel, out Dto_Company data, IMapper mapper)
        {
            //new CommProfile();
            data = ServiceLocator.staticMapper.Map<Dto_Company>(buModel);
        }

        public static void ToDtos(this List<Company> buModel, out List<Dto_Company> dtos, IMapper mapper)
        {
            dtos = ServiceLocator.staticMapper.Map<List<Company>, List<Dto_Company>>(buModel);
        }
    }
}
