

/****************************************************************************
* 类名：CustomExceptionFilter
* 描述：统一处理异常信息
* 创建人：Author
* 创建时间：208.04.22 16：43
* 修改人;Author
* 修改时间：2018.05.04
* 修改描述：
* **************************************************************************
*/

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Workflow.comm;
using Workflow.Dto.sys;

namespace Workflow.Core.Common
{
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {

        public override void OnException(ExceptionContext context)
        {
            //ILog log = LogManager.GetLogger(HttpContext.Current.Request.Url.LocalPath);
            //log.Error(context.Exception);
            DTO_ResponseMessage msg;
            BusinessException businessEx = context.Exception as BusinessException;
            if (businessEx != null)
            {
                msg = new DTO_ResponseMessage()
                {
                    code = businessEx.Code,
                    message = businessEx.Message,
                    status = false,
                    data = businessEx.Data
                };
            }
            else
            {
                msg = new DTO_ResponseMessage { status = false, code = null, data = null };

                msg.message = "服务器异常!";
                if (context.Exception is DbException)
                {
                    msg.code = "1001";
                    msg.message = "数据库异常";
                }
                else if (context.Exception is ArgumentException)
                {
                    msg.code = "5001";
                    msg.message = "参数异常";
                }
                else if (context.Exception is NullReferenceException)
                {
                    msg.code = "5002";
                    msg.message = "空指针异常";
                }
                else
                {
                    msg.code = "500";
                    msg.message = context.Exception.Message;
                }


                // LogHelper.ErrorLogRecord("4", context.Exception.GetType().Name, context.Exception).ConfigureAwait(false);
            }
            JsonResult result = new JsonResult(msg)
            {
                StatusCode = int.Parse(msg.code)
            };

            //var response = new HttpResponseMessage();
            //response.Content = new StringContent(JsonSerializer.SerializeToString(msg), Encoding.GetEncoding("utf-8"), "text/html");
            //result.Value = response;
            context.Result = result;
            base.OnException(context);
            //return response;
        }
    }
}
