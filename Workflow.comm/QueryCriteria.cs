/****************************************************************************
* 类名：QueryCriteria
* 描述：查询条件
* 创建人：Author
* 创建时间：2018.07.11 14:29
* 修改人;Author
* 修改时间：2018.07.11 14:29
* 修改描述：
* **************************************************************************
*/



using System;
using System.Collections.Generic;
using System.Text;

namespace Workflow.comm
{
    public class QueryCriteria
    {
        /// <summary>
        /// 页码
        /// </summary>
        public int page { get; set; }

        /// <summary>
        /// 条数
        /// </summary>
        public int size { get; set; }

        /// <summary>
        /// 要查询的条件-
        /// </summary>
        public string name { get; set; }
        
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? startTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? endTime { get; set; }

    }
}
