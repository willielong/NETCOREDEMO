using System.Collections.Generic;
using Workflow.Dto.business.Department;

namespace Workflow.Dto.business.Company
{
    public interface IDto_Company
    {
        string c_head { get; set; }
        List<Dto_Department> Departments { get; set; }
        string head { get; set; }
        string ognId { get; set; }
        string ognName { get; set; }
        string parent { get; set; }
        string parentId { get; set; }
        int sort { get; set; }
        int virOgn { get; set; }
        bool isTree { get; set; }
    }
}