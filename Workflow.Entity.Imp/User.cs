/****************************************************************************
* 类名：IUser
* 描述：用户实体接口
* 创建人：Author
* 创建时间：208.04.22 16：43
* 修改人;Author
* 修改时间：2018.05.04
* 修改描述：
* **************************************************************************
*/


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Workflow.Entity.Imp
{
    [Table("User")]
    public class User : EntityBase, IUser
    {
        /// <summary>
        /// 账号编号
        /// </summary>
        [StringLength(32), DisplayName("账号编号")]
        public virtual string account { get; set; }

        /// <summary>
        /// 用户中文名
        /// </summary>
        [StringLength(32), DisplayName("用户中文名")]
        public virtual string name { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        [DisplayName("头像")]
        public virtual string photo { get; set; }


        /// <summary>
        /// 邮箱
        /// </summary>
        [StringLength(32), DisplayName("邮箱")]
        public virtual string email { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [StringLength(32), DisplayName("密码")]
        public virtual string password { get; set; }

        /// <summary>
        /// 联系方式
        /// </summary>

        [StringLength(32), DisplayName("联系方式")]
        public virtual string phone { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        [DisplayName("年龄")]
        public virtual int age { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [DisplayName("性别"), StringLength(2)]
        public virtual string sex { get; set; }

        /// <summary>
        /// 通讯地址
        /// </summary>
        [DisplayName("通讯地址"), StringLength(256)]
        public virtual string address { get; set; }

        /// <summary>
        /// 毕业院校
        /// </summary>
        public virtual string school { get; set; }

        /// <summary>
        /// 用户编号
        /// </summary>
        [DisplayName("用户编号"),Key]
        public virtual string userId { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [DisplayName("排序")]
        public virtual int sort { get; set; }

        /// <summary>
        /// 进行多对多关系处理
        /// </summary>
        public virtual ICollection<UserKey> Departments { get; set; }

        /// <summary>
        /// 角色所对应的用户
        /// </summary>
        public virtual ICollection<UserRole> roles { get; set; }

        public virtual ICollection<OpreationMiddle> opmodel { get; set; }
    }
}
