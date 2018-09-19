/****************************************************************************
* 类名：UserRole
* 描述：角色-用户实体
* 创建人：李文龙
* 创建时间：208.05.06 10：43
* 修改人;李文龙
* 修改时间：2018.05.06
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
    [Table("UserRole")]
    public class UserRole : EntityBase, IUserRole
    {

        /// <summary>
        /// 角色编码
        /// </summary>
        public virtual string code { get; set; }


        /// <summary>
        /// 用户编号
        /// </summary>
        public virtual string user_id { get; set; }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int id { get; set; }
        

    }
}
