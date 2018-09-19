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
using System.Text;

namespace Workflow.Entity
{
    public interface IOgnBase : IEntityBase
    {
        /// <summary>
        /// 组织编号
        /// </summary>
        string ognId { get; set; }

        /// <summary>
        /// 组织名称
        /// </summary>
        string ognName { get; set; }

        /// <summary>
        /// 父级组织编号
        /// </summary>
        string parentId { get; set; }

        /// <summary>
        /// 负责人
        /// </summary>
        string head { get; set; }

        /// <summary>
        /// 协助负责人
        /// </summary>
        string c_head { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
        int sort { get; set; }
        
        /// <summary>
        /// 是否为虚拟组织
        /// </summary>
        int virOgn { get; set; }

        /// <summary>
        /// 是否显示在组织树中
        /// </summary>
        bool isTree { get; set; }


    }
}
