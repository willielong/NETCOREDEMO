using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Entity;

namespace Workflow.Dto.business.Department
{
    public class Dto_Department : IDepartment
    {
        public string branched { get; set; }
        public string unitId { get; set; }
        public string unit { get; set; }
        public string ognId { get; set; }
        public string ognName { get; set; }
        public string parentId { get; set; }
        public string head { get; set; }
        public string dis_head { get; set; }
        public string c_head { get; set; }
        public string dis_c_head { get; set; }
        public int sort { get; set; }
        public int virOgn { get; set; }
        public int enable { get; set; }
        public string caretor { get; set; }
        public DateTime? crateDate { get; set; }
        public string modifier { get; set; }
        public DateTime? modifierDate { get; set; }
        public bool isTree { get ; set ; }
    }
}
