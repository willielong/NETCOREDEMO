/****************************************************************************
* 类名：Operation
* 描述：操作-实体
* 创建人：李文龙
* 创建时间：208.04.22 16：43
* 修改人;李文龙
* 修改时间：2018.05.04
* 修改描述：
* **************************************************************************
*/

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Workflow.Entity.Imp
{
    public class Operation : EntityBase, IOperation
    {
        
        /// <summary>
        /// 操作名称
        /// </summary>
        public virtual string name { get; set; }

        /// <summary>
        /// 操作的样式
        /// </summary>
        public virtual string style_name { get; set; }

        /// <summary>
        /// 操作编码
        /// </summary>
        [Key]
        public virtual string operation_id { get; set; }

        /// <summary>
        /// 操作的级别 0-最低 1-一般 2全部操作
        /// </summary>
        public virtual int level { get; set; }

        public virtual ICollection<OpreationMiddle> opmodel { get; set; }
    }
}
