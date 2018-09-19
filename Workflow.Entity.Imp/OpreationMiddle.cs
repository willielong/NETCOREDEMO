
/****************************************************************************
* 类名：OpreationMiddle
* 描述：权限-角色-操作-用户—模块-实体
* 创建人：李文龙
* 创建时间：208.05.06 11：43
* 修改人;李文龙
* 修改时间：208.05.06 11：43
* 修改描述：
* **************************************************************************
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace Workflow.Entity.Imp
{
    public class OpreationMiddle : EntityBase, IOpreationMiddle
    {
        /// <summary>
        /// 模块编码
        /// </summary>
        public virtual string workbench_code { get; set; }

        /// <summary>
        /// 权限编号
        /// </summary>
        public virtual string permission_id { get; set; }

        /// <summary>
        /// 操作编码
        /// </summary>
        public virtual string operation_id { get; set; }

        /// <summary>
        /// 用户信息
        /// </summary>
        public virtual string person { get; set; }


        /// <summary>
        /// 用户类型1-角色 2-用户
        /// </summary>
        public virtual string type { get; set; }

        /// <summary>
        /// 主键
        /// </summary>
        public virtual int id { get; set; }
        

        #region 关系映射
        #endregion
    }
}
