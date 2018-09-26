using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.comm;
using Workflow.Entity.Imp.DataBase;

namespace Workflow.Core.Filter
{
    public class CustomAuthorize : AuthorizationHandler<CustomAauthorizeRequirement>
    { 
        
        /// <summary>
      /// 验证方案提供对象
      /// </summary>
        public IAuthenticationSchemeProvider Schemes { get; set; }

        public CustomAauthorizeRequirement customAauthorizeRequirement { get; set; }

        public CustomAuthorize(IAuthenticationSchemeProvider schemes)
        {
            Schemes = schemes;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, CustomAauthorizeRequirement requirement)
        {
            customAauthorizeRequirement = requirement;
            //从AuthorizationHandlerContext转成HttpContext，以便取出表求信息
            var httpContext = (context.Resource as Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext).HttpContext;
            //请求Url
            var questUrl = httpContext.Request.Path.Value.ToLower();
            //判断请求是否停止
            var handlers = httpContext.RequestServices.GetRequiredService<IAuthenticationHandlerProvider>();
            foreach (var scheme in await Schemes.GetRequestHandlerSchemesAsync())
            {
                var handler = await handlers.GetHandlerAsync(httpContext, scheme.Name) as IAuthenticationRequestHandler;
                if (handler != null && await handler.HandleRequestAsync())
                {
                    context.Fail();
                    return;
                }
            }
            //判断请求是否拥有凭据，即有没有登录
            var defaultAuthenticate = await Schemes.GetDefaultAuthenticateSchemeAsync();
            if (defaultAuthenticate != null)
            {
                var result = await httpContext.AuthenticateAsync(defaultAuthenticate.Name);
                //result?.Principal不为空即登录成功
                if (result?.Principal != null)
                {
                    ServiceLocator.currentUser = result.Principal.Identity.Name;
                    httpContext.User = result.Principal;                    
                    httpContext.Session.SetString("4A40B671-51EA-47B3-80CC-DD2426FB8DC2", result.Principal.Identity.Name);
                    
                    ////权限中是否存在请求的url
                    //if (Requirement.Permissions.GroupBy(g => g.Url).Where(w => w.Key.ToLower() == questUrl).Count() > 0)
                    //{
                    //    var name = httpContext.User.Claims.SingleOrDefault(s => s.Type == requirement.ClaimType).Value;
                    //    //验证权限
                    //    if (Requirement.Permissions.Where(w => w.Name == name && w.Url.ToLower() == questUrl).Count() <= 0)
                    //    {
                    //        //无权限跳转到拒绝页面
                    //        httpContext.Response.Redirect(requirement.DeniedAction);
                    //    }
                    //}
                    context.Succeed(requirement);
                    return;
                }
                else
                {
                    context.Fail();
                    return;
                }
            }
            context.Succeed(requirement);
        }
    }

    public class CustomAauthorizeRequirement : IAuthorizationRequirement
    {
        public CustomAauthorizeRequirement(string _ClaimType, SigningCredentials signingCredentials)
        {
            ClaimType = _ClaimType;
            Issuer = Workflow.comm.ServiceLocator.tokenHelper.Issuer;
            Audience = Workflow.comm.ServiceLocator.tokenHelper.Audience;
            Expiration = TimeSpan.FromMinutes(double.Parse(Workflow.comm.ServiceLocator.tokenHelper.Expiration));
            SigningCredentials = signingCredentials;
        }
        /// <summary>
        /// 认证授权类型
        /// </summary>
        public string ClaimType { internal get; set; }
        /// <summary>
        /// 发行人
        /// </summary>
        public string Issuer { get; set; }
        /// <summary>
        /// 订阅人
        /// </summary>
        public string Audience { get; set; }
        /// <summary>
        /// 过期时间
        /// </summary>
        public TimeSpan Expiration { get; set; } = TimeSpan.FromMinutes(5000);
        /// <summary>
        /// 签名验证
        /// </summary>
        public SigningCredentials SigningCredentials { get; set; }
    }
}
