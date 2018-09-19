/****************************************************************************
* 类名：IDepartment
* 描述：部门实体接口
* 创建人：Author
* 创建时间：208.04.22 16：43
* 修改人;Author
* 修改时间：2018.05.04
* 修改描述：
* **************************************************************************
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Workflow.Entity.Imp
{
    [Table("Department")]
    public class Department : OgnBase, IDepartment
    {
        /// <summary>
        /// 分管领导
        /// </summary>
        [StringLength(32), DisplayName("分管领导")]
        public virtual string branched { get; set; }

        /// <summary>
        /// 多对多获取部门用户
        /// </summary>
        public virtual ICollection<UserKey> users { get; set; }

        /// <summary>
        /// 单位编号
        /// </summary>
        [ForeignKey("unitId")]
        public virtual string unitId { get; set; }

       // public virtual Company company { get; set; }

    }
}
