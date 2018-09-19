using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Workflow.Entity.Imp
{
    public class BusinessEntityBase:IEntityBase
    {
        public BusinessEntityBase()
        {
        }

        /// <summary>
        /// 主键编号
        /// </summary>
        [Key]
        [DisplayName("表主键"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }

        /// <summary>
        /// 是否删除 0-未删除 1-删除 2-注销 3-禁用  
        /// </summary>
        [DisplayName("是否被删除")]
        public virtual int enable { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        /// 
        [DisplayName("创建人")]
        [StringLength(32)]
        public virtual string caretor { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public virtual DateTime? crateDate { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>mo
        [DisplayName("编辑人")]
        [StringLength(32)]
        public virtual string modifier { get; set; }


        /// <summary>
        /// 修改时间
        /// </summary>
        [DisplayName("编辑时间")]
        public virtual DateTime? modifierDate { get; set; }
    }
}
