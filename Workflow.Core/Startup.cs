/****************************************************************************
 * 类名：Startup
 * 描述：添加AUTOFAC注入的类及.NET 启动类
 * 创建人：系统
 * 创建时间：系统时间
 * 修改人;李文龙
 * 修改时间：2018.05.04
 * 修改描述：添加反射及读写分离的数据库操作
 * **************************************************************************
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Workflow.comm;

namespace Workflow.Core
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            Configuration = new ConfigurationBuilder().SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables().Build(); ;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //services.AddMvc();
            return Config.AutoFacConfig.Bootstrpper(services, Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
           
            app.UseCors(builder =>
            {
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
                //允许所有的来源地址跨域访问
                builder.AllowAnyOrigin();
            });
            app.UseAuthentication();//配置授权

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            ///进行注册
           // Config.AutoFacConfig.RegisterMappings();


            //var tokenValidationParameters = new TokenValidationParameters()
            //{
            //    ValidateIssuerSigningKey = true,
            //    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(ServiceLocator.tokenHelper.TokenSecreKey)),
            //    ValidateIssuer = true,
            //    ValidIssuer = ServiceLocator.tokenHelper.Issuer,
            //    ValidateAudience = true,
            //    ValidAudience = ServiceLocator.tokenHelper.Audience,
            //    ValidateLifetime = true,
            //    ClockSkew = TimeSpan.Zero
            //};
            //app.UseJwtBearerAuthentication(options: new JwtBearerOptions()
            //{
            //    AutomaticAuthenticate = true,
            //    AutomaticChallenge = true,
            //    TokenValidationParameters = tokenValidationParameters
            //});
            app.UseMvc();
        }
    }
}
