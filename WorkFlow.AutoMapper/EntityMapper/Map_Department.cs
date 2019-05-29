using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Workflow.comm;
using Workflow.Dto.business.Department;
using Workflow.Entity.Imp;

namespace WorkFlow.AutoMapper.EntityMapper
{
    public static class Map_Department
    {
        public static List<Dto_Department> ToDtoList(this List<Department> buModel, IMapper ma)
        {
            List<Dto_Department> data = ServiceLocator.staticMapper.Map<List<Department>, List<Dto_Department>>(buModel);
            return data;
        }
        public static Dto_Department ToDto(this Department buModel, IMapper ma)
        {
            //new CommProfile();
            Dto_Department data = ServiceLocator.staticMapper.Map<Dto_Department>(buModel);
            return data;
        }
    }
}
