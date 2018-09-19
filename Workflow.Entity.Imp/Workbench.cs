/****************************************************************************
* 类名：IPermission
* 描述：工作台-实体
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
    [Table("Workbench")]
    public class Workbench : EntityBase, IWorkbench
    {
        /// 模块
        /// </summary>
        public virtual string name { get; set; }
        /// <summary>
        /// 上级模块编号
        /// </summary>
        public virtual string parent_id { get; set; }

        /// <summary>
        /// 级别
        /// </summary>
        public virtual int level { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public virtual int sort { get; set; }

        /// <summary>
        /// 模块对应的样式
        /// </summary>
        public virtual string workbench_style { get; set; }


        /// <summary>
        /// 模块对应的网络地址
        /// </summary>
        public virtual string address { get; set; }

        /// <summary>
        /// 模块编码
        /// </summary>
        [Key]
        public virtual string workbench_code { get; set; }

        public virtual  ICollection<OpreationMiddle> opmodel { get; set; }
    }
}
