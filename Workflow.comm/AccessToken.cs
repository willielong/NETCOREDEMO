
/****************************************************************************
* 类名：AccessToken
* 描述：添加接口身份验证AccessToken
* 创建人：Author
* 创建时间：2018.9.18 10：52
* 修改人;Author
* 修改时间：2018.9.18 10：52
* 修改描述：
* **************************************************************************
*/

using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

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

    /// <summary>
    /// Token提供类
    /// </summary>
    public class TokenBusiness
    {
        public TokenBusiness()
        {
        }
        /// <summary>
        /// 生成令牌
        /// </summary>
        /// <param name="context">http上下文</param>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="role">角色</param>
        /// <returns></returns>
        public async Task<AccessToken> GenerateToken(HttpContext context, string username, string role)
        {
            var identity = await GetIdentity(username);
            if (identity == null)
            {
                return null;
            }
            var now = DateTime.UtcNow;
            //声明
            var claims = new Claim[]
            {
             new Claim(JwtRegisteredClaimNames.Sub,username),
             new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
             new Claim(JwtRegisteredClaimNames.Iat,ToUnixEpochDate(now).ToString(),ClaimValueTypes.Integer64),
             new Claim(ClaimTypes.Role,role),
             new Claim(ClaimTypes.Name,username)
            };

            var skey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(ServiceLocator.tokenHelper.TokenSecreKey));
            var signingCredentials = new SigningCredentials(skey, SecurityAlgorithms.HmacSha256);
            //Jwt安全令牌
            var jwt = new JwtSecurityToken(
                issuer: ServiceLocator.tokenHelper.Issuer,
                audience:ServiceLocator.tokenHelper.Audience,
                claims: claims,
                notBefore: now,
                expires: now.Add(TimeSpan.FromSeconds(double.Parse(ServiceLocator.tokenHelper.Expiration))),
                signingCredentials: signingCredentials);
            //生成令牌字符串
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            var response = new AccessToken
            {
                access_token = encodedJwt,
                expires_in = (TimeSpan.FromSeconds(double.Parse(ServiceLocator.tokenHelper.Expiration))).Seconds
            };
            return response;
        }

        private static long ToUnixEpochDate(DateTime date)
        {
            return (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
        }
        /// <summary>
        /// 查看令牌是否存在
        /// </summary>
        /// <param name="username">用户名</param>
        /// <returns></returns>
        private Task<ClaimsIdentity> GetIdentity(string username)
        {
            return Task.FromResult(
                new ClaimsIdentity(new System.Security.Principal.GenericIdentity(username, "token"),
                new Claim[] {
                 new Claim(ClaimTypes.Name, username)
                }));
        }
    }
}
