using System;
using System.Collections.Generic;
using System.Text;

namespace Workflow.comm
{
    /// <summary>
    /// 性别
    /// </summary>
    public enum Sex
    {
        /// <summary>
        /// 男性
        /// </summary>
        男 = 1,
        /// <summary>
        /// 女性
        /// </summary>
        女 = 2,
        /// <summary>
        /// 其他未知性别
        /// </summary>
        其他 = 0
    }

    /// <summary>
    /// 是否是成年人
    /// </summary>
    public enum Adult
    {
        /// <summary>
        /// 成年
        /// </summary>
        成年 = 1,
        /// <summary>
        /// 未成年
        /// </summary>
        未成年 = 2,
    }

    /// <summary>
    /// 政治面貌
    /// </summary>
    public enum Political
    {
        中共党员 = 1,
        共青团员 = 2,
        少先队员 = 3,
        群众 = 4,
    }

    /// <summary>
    /// 英文一周日期
    /// </summary>
    public enum Week_en
    {
        Monday = 1,
        Tuesday = 2,
        Wednesday = 3,
        Thursday = 4,
        Friday = 5,
        Saturday = 6,
        Sunday = 7
    }

    /// <summary>
    /// 中文一周日期
    /// </summary>
    public enum Week_zh
    {
        一 = 1,
        二 = 2,
        三 = 3,
        四 = 4,
        五 = 5,
        六 = 6,
        七 = 7
    }

    /// <summary>
    /// 中文的是星期还是周
    /// </summary>
    public enum WeekHead_zh
    {
        周 = 1,
        星期 = 2,
    }
}
