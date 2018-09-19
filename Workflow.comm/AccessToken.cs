
/****************************************************************************
* 类名：AccessToken
* 描述：添加接口身份验证AccessToken
* 创建人：李文龙
* 创建时间：2018.9.18 10：52
* 修改人;李文龙
* 修改时间：2018.9.18 10：52
* 修改描述：
* **************************************************************************
*/

using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Workflow.comm
{
    /// <summary>
    /// 接口身份验证AccessToken 类
    /// </summary>
    public class AccessToken
    {
        /// <summary>
        /// token字符串
        /// </summary>
        public string access_token { get; set; }


        /// <summary>
        /// 过期时间
        /// </summary>
        public int expires_in { get; set; }


    }

    /// <summary>
    /// token提供属性
    /// </summary>
    public class TokenProviderOptions
    {
        /// <summary>
        /// 发行人
        /// </summary>
        public string Issuer { get; set; }
        
        /// <summary>
        /// 订阅者
        /// </summary>
        public string Audience { get; set; }
        
        /// <summary>
        /// 过期时间间隔
        /// </summary>
        public TimeSpan Expiration { get; set; } = TimeSpan.FromSeconds(30);
        
        /// <summary>
        /// 签名证书
        /// </summary>
        public SigningCredentials SigningCredentials { get; set; }
    }
}
