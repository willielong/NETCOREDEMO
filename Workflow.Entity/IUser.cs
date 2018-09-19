/****************************************************************************
* 类名：IUser
* 描述：用户实体接口
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
    public interface IUser:IEntityBase
    {
        /// <summary>
        /// 账号编号
        /// </summary>
        string account { get; set; }

        /// <summary>
        /// 用户中文名
        /// </summary>
        string name { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        string photo { get; set; }


        /// <summary>
        /// 邮箱
        /// </summary>
        string email { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        string password { get; set; }

        /// <summary>
        /// 联系方式
        /// </summary>
        string phone { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        int age { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        string sex { get; set; }

        /// <summary>
        /// 通讯地址
        /// </summary>
        string address { get; set; }

        /// <summary>
        /// 用户编号
        /// </summary>
        string userId { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        int sort { get; set; }
    }
}
