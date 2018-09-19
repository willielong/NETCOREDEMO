/****************************************************************************
* 类名：IOpreationMiddle
* 描述：权限-角色-操作-用户—模块-实体
* 创建人：Author
* 创建时间：208.04.22 16：43
* 修改人;Author
* 修改时间：2018.05.04
* 修改描述：
* **************************************************************************
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace Workflow.Entity
{
    public interface IOpreationMiddle : IEntityBase
    {
        /// <summary>
        /// 模块编码
        /// </summary>
        string workbench_code { get; set; }

        /// <summary>
        /// 权限编号
        /// </summary>
        string permission_id { get; set; }

        /// <summary>
        /// 操作编码
        /// </summary>
        string operation_id { get; set; }

        /// <summary>
        /// 用户信息
        /// </summary>
        string person { get; set; }


        /// <summary>
        /// 用户类型1-角色 2-用户
        /// </summary>
        string type { get; set; }

        /// <summary>
        /// 主键
        /// </summary>
        int id { get; set; }
    }
}
