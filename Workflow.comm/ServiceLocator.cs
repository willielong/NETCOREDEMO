/****************************************************************************
* 类名：ServiceLocator
* 描述：手动获取DI中注入的对象
* 创建人：Author
* 创建时间：208.5.14 16：43
* 修改人;Author
* 修改时间：2018.05.04
* 修改描述：
* **************************************************************************
*/


using AutoMapper;
using log4net;
using log4net.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Workflow.comm
{
    public static class ServiceLocator
    {
        /// <summary>
        /// 写数据库
        /// </summary>
        public static DbContext writeContext { get; set; }

        /// <summary>
        /// 读数据库
        /// </summary>
        public static DbContext readContext { get; set; }

        /// <summary>
        /// AutoMapper映射
        /// </summary>
        public static IMapper mapper { get; set; }

        /// <summary>
        /// 日志仓储
        /// </summary>
        public static ILoggerRepository log4netRepository { get; set; }

        /// <summary>
        /// 客户端的IP地址
        /// </summary>
        public static string Ip { get; set; }
        
        /// <summary>
        /// 当前访问的用户
        /// </summary>
        public static string currentUser { get; set; }

        public static TokenHelper tokenHelper { get; set; }

        public static string log4netRepositoryName { get; set; } = "NETCoreRepository";


        public static IMapper staticMapper { get; set; }
    }
}
