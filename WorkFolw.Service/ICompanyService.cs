using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Dto.business.Company;

namespace WorkFolw.Service
{
    public interface ICompanyService
    {
        List<Dto_Company> Get();
        Dto_Company Single();
    }
}
