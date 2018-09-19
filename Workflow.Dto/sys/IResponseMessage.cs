
/*
 * 目的：返回请求结果
 * 创建人：李文龙
 * 创建时间：208.04.22 16:56
 * 修改人;
 * 修改目的：
 * 修改时间
 * 修改结果：
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace Workflow.Dto.sys
{
    public interface IResponseMessage
    {
        bool status { get; set; }
        string code { get; set; }
        string message { get; set; }
        object data { get; set; }
    }

}
