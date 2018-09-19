/****************************************************************************
* 类名：IPermission
* 描述：权限-实体
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
    public interface IPermission : IEntityBase
    {

        /// <summary>
        /// 权限名称
        /// </summary>
        string name { get; set; }
       
        /// <summary>
        /// 权限编号
        /// </summary>
        string permission_id { get; set; }

        /// <summary>
        /// 权限级别
        /// </summary>
        int level { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        int sort { get; set; }
    }
}
