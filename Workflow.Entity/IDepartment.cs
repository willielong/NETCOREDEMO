/****************************************************************************
* 类名：IDepartment
* 描述：部门实体接口
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
    public interface IDepartment:IOgnBase
    {
        /// <summary>
        /// 分管领导
        /// </summary>
        string branched { get; set; }


        /// <summary>
        /// 单位编号
        /// </summary>
        string unitId { get; set; }
        
    }
}
