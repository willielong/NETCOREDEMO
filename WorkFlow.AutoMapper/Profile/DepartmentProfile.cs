using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Dto.business.Department;
using Workflow.Entity.Imp;

namespace WorkFlow.AutoMapper
{
    public class DepartmentProfile : Profile, ICommProfile
    {
        public DepartmentProfile()
        {
            CreateMap<Department, Dto_Department>();
            CreateMap<Dto_Department, Department>();
        }
    }
}
