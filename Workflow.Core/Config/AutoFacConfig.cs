
/****************************************************************************
* 类名：AutoFacConfig
* 描述：将第三方的组件接管到程序
* 创建人：Author
* 创建时间：2018.05.04 
* 修改人;Author
* 修改时间：2018.09.18
* 修改描述：1、添加反射及读写分离的数据库操作
*           2、添加身份认证-jwt授权
* **************************************************************************
*/

using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using log4net;
using log4net.Config;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
//using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using Workflow.comm;
using Workflow.Core.Common;
using Workflow.Core.Filter;
using Workflow.Repository;
using Workflow.Repository.Imp;
using WorkFlow.AutoMapper;

namespace Workflow.Core.Config
{
    public class AutoFacConfig
    {
        public static IServiceProvider Bootstrpper(IServiceCollection services, IConfiguration Configuration)
        {
            ///添加跨域
            services.AddCors();

            services.AddAutoMapper();

            ///添加json序列化         
            services.AddMvc(options => { options.Filters.Add(typeof(CustomExceptionFilter)); }).AddJsonOptions(options => options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss"); ;

            //services.AddAutoMapper();
            //services.AddMvc();

            ///获取数据连接
            var dbConnection = GetDbBaseConnection();
            /////添加写的数据库线程
            //services.AddDbContext<WriteDbContext>(dboptions => dboptions.UseSqlServer(dbConnection.ms_write_connection, db =>
            //{
            //    db.UseRowNumberForPaging();
            //    //db.MigrationsAssembly("Workflow.Core"); 
            //}));

            ///// 添加读的数据库线程
            //services.AddDbContext<ReadDbContext>(dboptions => dboptions.UseSqlServer(dbConnection.ms_read_connection, db => db.UseRowNumberForPaging()));


            /////添加写的数据库线程
            //services.AddDbContext<WriteDbContext>(dboptions => dboptions.UseSqlServer(dbConnection.ms_write_connection, db =>
            //{
            //    db.UseRowNumberForPaging();
            //    //db.MigrationsAssembly("Workflow.Core"); 
            //}));

            ///// 添加读的数据库线程
            //services.AddDbContext<ReadDbContext>(dboptions => dboptions.UseSqlServer(dbConnection.ms_read_connection, db => db.UseRowNumberForPaging()));

            //var assemblyS = Assembly.Load("Workflow.ServiceImp");
            //var assemblyB = Assembly.Load("WorkFlow.Business.Imp");

            services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.All));
            services.AddSingleton(sp => RegisterMappingConfig().CreateMapper());
            ///配置jwt授权
            ServiceLocator.tokenHelper = Config.AutoFacConfig.GetTokenHelper();

            var skey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(ServiceLocator.tokenHelper.TokenSecreKey));
            var signingCredentials = new SigningCredentials(skey, SecurityAlgorithms.HmacSha256);

            services.AddAuthorization(opt =>
            {
                var permissionRequirement = new CustomAauthorizeRequirement(ClaimTypes.Role, signingCredentials);
                opt.AddPolicy("CustomAuthorize", policy => policy.Requirements.Add(permissionRequirement));
            }).AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer((jwtOptions) =>
            {
                jwtOptions.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = skey,
                    ValidateIssuer = true,
                    ValidIssuer = ServiceLocator.tokenHelper.Issuer,
                    ValidateAudience = true,
                    ValidAudience = ServiceLocator.tokenHelper.Audience,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });

            //注入授权Handler
            services.AddSingleton<IAuthorizationHandler, CustomAuthorize>();
            //services.AddSession();
            services.AddDistributedMemoryCache();
            services.AddSession();
            ////添加接口文档自动生成第三方键
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "接口文档",
                    Description = "RESTful API for NetCore",
                    TermsOfService = "None",
                    Contact = new Contact { Name = "", Email = "", Url = "" }
                });

                //Set the comments path for the swagger json and ui.
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, "ApiDoc.xml");
                c.IncludeXmlComments(xmlPath);

                c.OperationFilter<HttpHeaderOperation>(); // 添加httpHeader参数
            });
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            ///添加接口版本管理中间件
            services.AddApiVersioning(opt =>
            {
                opt.ReportApiVersions = true;
                opt.ApiVersionReader = new QueryStringApiVersionReader(parameterName: "version");
                opt.AssumeDefaultVersionWhenUnspecified = true;
                opt.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
            });

            var builder = new ContainerBuilder();//实例化 AutoFac  容器  

            //GetAssmenBlys();
            ///将项目集注入到到反射集合
            builder.RegisterAssemblyTypes(GetAssmenBlys())
                .AsImplementedInterfaces()//表示以接口的方式注入
                .InstancePerLifetimeScope(); //在一个生命周期域中，每一个依赖或调用创建一个单一的共享的实例，且每一个不同的生命周期域，实例是唯一的，不共享的。
            builder.Populate(services);
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>))//单个注入
    .InstancePerDependency();

            IContainer ApplicationContainer = builder.Build();
            IServiceProvider serviceProvider = new AutofacServiceProvider(ApplicationContainer);

            ///进行数据库/表创建
            // serviceProvider.GetService<WriteDbContext>().Database.EnsureCreated();

            ///手动的将数据库连接对象放入到自己的对象中
            //ServiceLocator.readContext = serviceProvider.GetService<ReadDbContext>();
            //ServiceLocator.writeContext = serviceProvider.GetService<WriteDbContext>();
            ServiceLocator.mapper = serviceProvider.GetService<IMapper>();
            //new SerssionHelper().WriteMapper(mapper);
            ///注入log4net
            var repository = LogManager.CreateRepository(ServiceLocator.log4netRepositoryName);
            XmlConfigurator.Configure(repository, new FileInfo("Config\\log4net.config"));
            return serviceProvider;//第三方IOC接管 core内置DI容器  
        }

        /// <summary>
        /// 返回需要依赖注入的接口
        /// </summary>
        /// <returns></returns>
        public static Assembly[] GetAssmenBlys()
        {
            IConfigFile con = new GeneralConfFileOperator();
            Assemblys assembly = new Assemblys();
            string path = Directory.GetCurrentDirectory() + "\\Config\\Assemblys.xml";
            assembly = con.ReadConfFile<Assemblys>(path, false);
            //assembly.childs.Add("12312312");
            //assembly.childs.Add("123");
            //con.WriteConfFile(assembly, path, false, false);
            List<Assembly> assemblys = new List<Assembly>();
            if (assembly.childs.Count > 0)
            {
                foreach (var item in assembly.childs)
                {
                    assemblys.Add(Assembly.Load(item));
                }

            }
            return assemblys.ToArray();
        }

        /// <summary>
        /// 读取配置文件
        /// </summary>
        /// <returns></returns>
        public static DBHelper GetDbBaseConnection()
        {
            DBHelper dbConnection = new DBHelper();
            IConfigFile con = new GeneralConfFileOperator();
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Config", "DBHelper.xml");
            dbConnection = con.ReadConfFile<DBHelper>(path, false);
            return dbConnection;
        }

        /// <summary>
        /// 进行数据映射的三方插件引入
        /// </summary>
        public static void RegisterMappings()
        {
            //获取所有IProfile实现类
            var allType =
            Assembly
               .GetEntryAssembly()//获取默认程序集
               .GetReferencedAssemblies()//获取所有引用程序集
               .Select(Assembly.Load)
               .SelectMany(y => y.DefinedTypes)
               .Where(type => typeof(ICommProfile).GetTypeInfo().IsAssignableFrom(type.AsType()));
            Mapper.Initialize(y =>
                               {
                                   foreach (var typeInfo in allType)
                                   {
                                       var type = typeInfo.AsType();
                                       if (type.Equals(typeof(ICommProfile)))
                                       {
                                           //注册映射
                                           y.AddProfiles(type); // Initialise each Profile classe
                                           ///Mapper.AddProfile(Activator.CreateInstance(type) as Profile);
                                       }
                                   }
                               });
        }

        public static MapperConfiguration RegisterMappingConfig()
        {
            //获取所有IProfile实现类
            var allType =
            Assembly
               .GetEntryAssembly()//获取默认程序集
               .GetReferencedAssemblies()//获取所有引用程序集
               .Select(Assembly.Load)
               .SelectMany(y => y.DefinedTypes)
               .Where(type => typeof(ICommProfile).GetTypeInfo().IsAssignableFrom(type.AsType()));
            return new MapperConfiguration(cfg =>
            {
                foreach (var typeInfo in allType)
                {
                    var type = typeInfo.AsType();
                    if (type.Equals(typeof(ICommProfile)))
                    {
                        //注册映射
                        cfg.AddProfiles(type); // Initialise each Profile classe
                                               ///Mapper.AddProfile(Activator.CreateInstance(type) as Profile);
                    }
                }
            });
        }

        /// <summary>
        /// 获取生成Token的配置
        /// </summary>
        /// <returns></returns>
        public static TokenHelper GetTokenHelper()
        {
            TokenHelper tokenHelper = new TokenHelper();
            IConfigFile con = new GeneralConfFileOperator();
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Config", "TokenHelper.xml");
            tokenHelper = con.ReadConfFile<TokenHelper>(path, false);
            return tokenHelper;
        }
    }
}
