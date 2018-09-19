
/****************************************************************************
* 类名：UserKey
* 描述：用户-组织-多对多实体接口
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
    [Table("UserKey")]
    public class UserKey : EntityBase, IUserKey
    {
        [Key, DisplayName("表主键"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int id { get; set; }
        /// <summary>
        /// 部门编号
        /// </summary>
        [DisplayName("部门编号")]
        public virtual string ognId { get; set; }

        /// <summary>
        /// 用户编号
        /// </summary>
        [DisplayName("用户编号")]
        public virtual string userId { get; set; }
        
    }
}
