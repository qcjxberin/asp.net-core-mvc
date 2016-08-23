using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.Redis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;
using wkmvc.Data;
using wkmvc.Redis;

namespace wkmvc
{
    public class Startup
    {
        private readonly Platform _platform;
        private readonly DataBaseProvider _dataBaseProvider;
        private readonly CacheProvider _cacheProvider;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            if (env.IsDevelopment())
            {
                builder.AddApplicationInsightsSettings(developerMode: true);
            }
            Configuration = builder.Build();
            _platform = new Platform();
            _dataBaseProvider = new DataBaseProvider();
            _cacheProvider = new CacheProvider();
        }

        public IConfigurationRoot Configuration { get; }

        // 运行时调用此方法,并使用此方法将服务添加到容器中
        public void ConfigureServices(IServiceCollection services)
        {
            // 添加框架服务
            services.AddApplicationInsightsTelemetry(Configuration);

            if (_platform.UseInMemoryStore)
            {
                services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase());
            }
            else
            {
                if (_dataBaseProvider._isSqlServer())
                    services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SqlServerConnection")));
                if (_dataBaseProvider._isMySql())
                    services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(Configuration.GetConnectionString("MySqlConnection")));
                //if (_dataBaseProvider._isOracle())

            }

            services.AddMemoryCache();

            if (_cacheProvider._isUseRedis())
            {
                services.AddSingleton(typeof(ICacheService), new RedisCacheService(new RedisCacheOptions
                {
                    Configuration = _cacheProvider._connectionString(),
                    InstanceName = _cacheProvider._instanceName()
                }));
            }
            else
            {
                services.AddSingleton<IMemoryCache>(factory =>
                {
                    var cache = new MemoryCache(new MemoryCacheOptions());
                    return cache;
                });
                services.AddSingleton<ICacheService, MemoryCacheService>();
            }



            services.AddMvc().AddJsonOptions(options=> { options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver(); });

            // 添加工作单元
            services.AddTransient<Core.IUnitOfWork,Core.UnitOfWork>();


            #region 添加应用程序服务

            //系统管理员
            services.AddTransient<Core.IServices.IUserService, Core.ServicesImp.UserService>();
            //系统模块
            services.AddTransient<Core.IServices.IModuleService, Core.ServicesImp.ModuleService>();

            #endregion

            #region 添加领域服务

            // 添加系统初始化服务
            services.AddTransient<Services.InitalServices.InitalSystemServices>();
            // 添加配置管理服务
            services.AddTransient<Services.ConfigServices.AppConfigurtaionServices>();
            // 系统管理员管理服务
            services.AddTransient<Services.SysServices.SysUserServices>();
            // 系统图形验证码服务
            services.AddTransient<Services.ComServices.VierificationCodeServices>();

            #endregion
        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            //loggerFactory.AddConsole(LogLevel.Debug);

            app.UseApplicationInsightsRequestTelemetry();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseWkMvcDI();

            app.UseApplicationInsightsExceptionTelemetry();
            //静态资源
            app.UseStaticFiles();
            //路由配置
            ConfigRoute(app);
            
        }

        /// <summary>
        /// 配置路由
        /// </summary>
        /// <param name="app"></param>
        public void ConfigRoute(IApplicationBuilder app)
        {
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areaRoute",
                    template: "{area:exists}/{controller}/{action=Index}/{id?}");
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
