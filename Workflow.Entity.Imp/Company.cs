
/****************************************************************************
* 类名：ICompany
* 描述：单位实体接口
* 创建人：Author
* 创建时间：208.04.22 16：43
* 修改人;Author
* 修改时间：2018.05.04
* 修改描述：
* **************************************************************************
*/
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Workflow.Entity.Imp
{
    //[Table("Company")]
    public class Company : OgnBase, ICompany
    {
        public Company() { Departments = new Collection<Department>(); }
        /// <summary>
        /// 一对多的方式获取单位下所有的部门
        /// </summary>
        public virtual ICollection<Department> Departments { get; set; }
    }
}
