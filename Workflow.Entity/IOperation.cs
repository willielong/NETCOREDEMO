/****************************************************************************
* 类名：IOperation
* 描述：操作-实体
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
    public interface IOperation : IEntityBase
    {
        /// <summary>
        /// 操作名称
        /// </summary>
        string name { get; set; }

        /// <summary>
        /// 操作的样式
        /// </summary>
        string style_name { get; set; }

        /// <summary>
        /// 操作编码
        /// </summary>
        string operation_id { get; set; }

        /// <summary>
        /// 操作的级别 0-最低 1-一般 2全部操作
        /// </summary>
        int level { get; set; }
    }
}
