
/****************************************************************************
* 类名：IUserKey
* 描述：用户-组织-多对多实体接口
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
    public interface IUserKey:IEntityBase
    {
        /// <summary>
        /// 用户比编号
        /// </summary>
        string ognId { get; set; }

        /// <summary>
        /// 用户编号
        /// </summary>
        string userId { get; set; }
        
    }
}
