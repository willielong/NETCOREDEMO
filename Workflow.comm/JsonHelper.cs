
/****************************************************************************
* 类名：JsonHelper
* 描述：将对象转化成HttpResponeMessage-暂弃
* 创建人：Author
* 创建时间：2018.05.04 
* 修改人;Author
* 修改时间：2018.05.04
* 修改描述：添加反射及读写分离的数据库操作
* **************************************************************************
*/

using Microsoft.AspNetCore.Mvc;
using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;


namespace Workflow.comm
{
    public static class JsonHelper
    {
        public static object ToJson(this object obj)
        {
            var str = "";
            var responseMsg = new HttpResponseMessage();

            if (obj is string || obj is char)
            {
                str = obj.ToString();
            }
            else
            {
                str = JsonSerializer.SerializeToString(obj);

                //if (((Dto_ResponseMessage)obj).status)
                //    responseMsg.StatusCode = HttpStatusCode.OK;
                //else
                //    responseMsg.StatusCode = HttpStatusCode.InternalServerError;
            }

            responseMsg.Content = new StringContent(str, Encoding.GetEncoding("utf-8"), "text/html");

            return responseMsg;
        }

        public static object ToImage(this object obj, string contentType = "")
        {
            var type = contentType == "" ? "PNG" : contentType;
            var responseMsg = new HttpResponseMessage(HttpStatusCode.OK);

            if (obj != null)
            {
                if (obj is byte[])
                {
                    responseMsg.Content = new ByteArrayContent((byte[])obj);
                    responseMsg.Content.Headers.ContentType = new MediaTypeHeaderValue(type);
                }
            }

            return responseMsg;
        }

        /// <summary>
        /// 将字符串转换成实体类
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Json"></param>
        /// <returns></returns>
        public static T ToEntity<T>(this string Json)
        {
            return JsonSerializer.DeserializeFromString<T>(Json);
        }
        /// <summary>
        /// 将实体类转换成字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Json"></param>
        /// <returns></returns>
        public static string ToJsonString(this object Json)
        {
            return JsonSerializer.SerializeToString(Json);
        }

        public static JsonResult ToJsonResult(this object data)
        {
            return new JsonResult(data);
        }
    }
}