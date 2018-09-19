/****************************************************************************
* 类名：IPermission
* 描述：工作台-实体
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
    public interface IWorkbench:IEntityBase
    {
        /// <summary>
        /// 模块
        /// </summary>
        string name { get; set; }
        /// <summary>
        /// 上级模块编号
        /// </summary>
        string parent_id { get; set; }

        /// <summary>
        /// 级别
        /// </summary>
        int level { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        int sort { get; set; }

        /// <summary>
        /// 模块对应的样式
        /// </summary>
        string workbench_style { get; set; }


        /// <summary>
        /// 模块对应的网络地址
        /// </summary>
        string address { get; set; }

        /// <summary>
        /// 模块编码
        /// </summary>
        string workbench_code { get; set; }
    }
}
