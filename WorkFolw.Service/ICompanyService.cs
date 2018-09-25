using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Dto.business.Company;
using Workflow.Dto.sys;

namespace WorkFolw.Service
{
    public interface ICompanyService
    {
        List<Dto_Company> Get();
        IResponseMessage Single();
    }
}
