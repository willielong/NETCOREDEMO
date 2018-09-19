/****************************************************************************
* 类名：IEntityBase
* 描述：基础实体接口
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
    public interface IEntityBase
    {
        ///// <summary>
        ///// 主键编号
        ///// </summary>
        //int Id { get; set; }

        /// <summary>
        /// 是否删除 0-未删除 1-删除 2-注销 3-禁用  
        /// </summary>
        int enable { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        string caretor { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        DateTime? crateDate { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>
        string modifier { get; set; }


        /// <summary>
        /// 修改时间
        /// </summary>
        DateTime? modifierDate { get; set; }
    }
}
