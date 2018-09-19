/****************************************************************************
* 类名：Dto_Company
* 描述：UI层MODEL-单位
* 创建人：Author
* 创建时间：2018.06.09 
* 修改人;Author
* 修改时间：2018.06.09
* 修改描述：
* **************************************************************************
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Workflow.Dto.business.Department;
using Workflow.Entity.Imp;

namespace Workflow.Dto.business.Company
{
    public class Dto_Company : IDto_Company
    {
        public Dto_Company() { }
        /// <summary>
        /// 组织编号
        /// </summary>
        public virtual string ognId { get; set; }

        /// <summary>
        /// 组织名称
        /// </summary>
        public virtual string ognName { get; set; }

        /// <summary>
        /// 父级组织编号
        /// </summary>
        public virtual string parentId { get; set; }

        /// <summary>
        /// 父组织
        /// </summary>
        public virtual string parent { get; set; }

        /// <summary>
        /// 负责人
        /// </summary>
        public virtual string head { get; set; }
        public virtual string dis_head { get; set; }

        /// <summary>
        /// 协助负责人
        /// </summary>
        public virtual string c_head { get; set; }
        public virtual string dis_c_head { get; set; }


        /// <summary>
        /// 排序字段
        /// </summary>

        public virtual int sort { get; set; }

        /// <summary>
        /// 是否为虚拟组织
        /// </summary>
        public virtual int virOgn { get; set; }

        /// <summary>
        /// 一对多的方式获取单位下所有的部门
        /// </summary>
        public virtual List<Dto_Department> Departments { get; set; }
        /// <summary>
        /// 是否显示
        /// </summary>
        public bool isTree { get; set; }
        public string id { get; set; }
    }
}
