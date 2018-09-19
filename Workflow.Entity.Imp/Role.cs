

/****************************************************************************
* 类名：IRole
* 描述：角色
* 创建人：李文龙
* 创建时间：208.04.22 16：43
* 修改人;李文龙
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
    [Table("Role")]
    public class Role : EntityBase, IRole
    {
        /// <summary>
        /// 角色编码
        /// </summary>
        [Key, DisplayName("角色编码")]
        public virtual string code { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        [DisplayName("角色名称")]
        public virtual string name { get; set; }

        /// <summary>
        /// 角色类型 0-系统角色 1-系统代码 2-与部门相关的角色 3-自定义角色
        /// </summary>
        [DisplayName("角色类型")]
        public virtual int sys_type { get; set; }

        /// <summary>
        /// 默认人
        /// </summary>
        [DisplayName("默认人")]
        public virtual string default_user_id { get; set; }

        /// <summary>
        /// 角色所对应的用户
        /// </summary>
        public virtual ICollection<UserRole> users { get; set; }
        public virtual ICollection<OpreationMiddle> opmodel { get; set; }

    }
}
