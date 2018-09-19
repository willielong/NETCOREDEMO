/****************************************************************************
* 类名：IOgnBase
* 描述：组织基础实体接口
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
using System.Text;

namespace Workflow.Entity.Imp
{
    public class OgnBase : EntityBase, IOgnBase
    {

        /// <summary>
        /// 组织编号
        /// </summary>
        [DisplayName("组织编号"), MaxLength(32), Key]
        public virtual string ognId { get; set; }

        /// <summary>
        /// 组织名称
        /// </summary>
        [DisplayName("组织名称"), MaxLength(32)]
        public virtual string ognName { get; set; }

        /// <summary>
        /// 父级组织编号
        /// </summary>
        [DisplayName("父级组织编号"), MaxLength(32)]
        public virtual string parentId { get; set; }

        /// <summary>
        /// 负责人
        /// </summary>
        [DisplayName("负责人"), MaxLength(32)]
        public virtual string head { get; set; }

        /// <summary>
        /// 协助负责人
        /// </summary>
        [DisplayName("协助负责人"), MaxLength(32)]
        public virtual string c_head { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>

        [DisplayName("排序字段")]
        public virtual int sort { get; set; }

        /// <summary>
        /// 是否为虚拟组织
        /// </summary>
        [DisplayName("是否为虚拟组织")]
        public virtual int virOgn { get; set; }
        /// <summary>
        /// 是否显示到组织树
        /// </summary>
        [DisplayName("是否显示到组织树")]
        public bool isTree { get; set; }
    }
}
