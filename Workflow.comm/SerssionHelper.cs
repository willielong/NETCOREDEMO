using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using ServiceStack.Text;
using Microsoft.AspNetCore.Http.Abstractions;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Http.Features;
using Workflow.Entity;

namespace Workflow.comm
{
    public static class SerssionHelper
    {


        /// <summary>
        /// 将用户信息 写入到session
        /// </summary>
        /// <param name="mapper"></param>
        public static void WriteUserSession(this IHttpContextAccessor httpContextAccessor, IUser user)
        {
            httpContextAccessor.HttpContext.Session.SetString("4A40B671-51EA-47B3-80CC-DD2426FB8DC2", JsonSerializer.SerializeToString<IUser>(user));
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        public static IUser GetUserSession(this IHttpContextAccessor httpContextAccessor)
        {
            return JsonSerializer.DeserializeFromString<IUser>(httpContextAccessor.HttpContext.Session.GetString("4A40B671-51EA-47B3-80CC-DD2426FB8DC2"));
        }
    }

}
