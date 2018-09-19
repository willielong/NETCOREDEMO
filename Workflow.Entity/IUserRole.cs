/****************************************************************************
* 类名：IUserRole
* 描述：角色-用户实体
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
    public interface IUserRole:IEntityBase
    {
        /// <summary>
        /// 角色编码
        /// </summary>
        string code { get; set; }


        /// <summary>
        /// 用户编号
        /// </summary>
        string user_id { get; set; }

        int id { get; set; }
    }
}
