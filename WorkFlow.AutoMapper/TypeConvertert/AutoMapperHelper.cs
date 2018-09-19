using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Entity.Imp.DataBase;
using Workflow.Repository;

namespace WorkFlow.AutoMapper.TypeConvertert
{
    public static class AutoMapperHelper
    {
        //[Injection]
        public static WriteDbContext context { get; set; }
        //public static ireq
        //public static IServiceProvider Services { get; set; }
        public static string ToCompanyName(this string companyId)
        {
           
            return "";
        }
    }
}
