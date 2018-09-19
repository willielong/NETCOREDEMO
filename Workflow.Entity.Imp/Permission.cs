/****************************************************************************
* 类名：IPermission
* 描述：权限-实体
* 创建人：Author
* 创建时间：208.04.22 16：43
* 修改人;Author
* 修改时间：2018.05.04
* 修改描述：
* **************************************************************************
*/

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Workflow.Entity.Imp
{
    [Table("Permission")]
    public class Permission:EntityBase,IPermission
    {
        /// <summary>
        /// 权限名称
        /// </summary>
        public virtual string name { get; set; }

        /// <summary>
        /// 权限编号
        /// </summary>
        [Key]
        public virtual string permission_id { get; set; }

        /// <summary>
        /// 权限级别
        /// </summary>
        public virtual int level { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public virtual int sort { get; set; }
        public virtual ICollection<OpreationMiddle> opmodel { get; set; }
    }
}
