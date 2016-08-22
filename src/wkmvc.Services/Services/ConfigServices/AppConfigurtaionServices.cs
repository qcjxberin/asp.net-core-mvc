using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace wkmvc.Services.ConfigServices
{
    /// <summary>
    /// Describe：网站配置服务
    /// Author：YuanGang
    /// Date：2016/08/04
    /// Blogs:http://www.cnblogs.com/yuangang
    /// </summary>
    public class AppConfigurtaionServices
    {
        /// <summary>
        /// 获取自定义配置文件配置
        /// </summary>
        /// <typeparam name="T">配置模型</typeparam>
        /// <param name="key">根节点</param>
        /// <param name="configPath">配置文件名称</param>
        /// <returns></returns>
        public T GetAppSettings<T>(string key,string configPath= "siteconfig.json") where T:class,new()
        {
            IConfiguration config = new ConfigurationBuilder()
                .Add(new JsonConfigurationSource { Path= configPath, ReloadOnChange=true })
                .Build();

            var appconfig= new ServiceCollection()
                .AddOptions()
                .Configure<T>(config.GetSection(key))//需添加扩展类 Microsoft.Extensions.Options.ConfigurationExtensions （Install-Package Microsoft.Extensions.Options.ConfigurationExtensions）
                .BuildServiceProvider()
                .GetService<IOptions<T>>()
                .Value;

            return appconfig;
        }
        /// <summary>
        /// 获取自定义配置文件配置（异步方式）
        /// </summary>
        /// <typeparam name="T">配置模型</typeparam>
        /// <param name="key">根节点</param>
        /// <param name="configPath">配置文件名称</param>
        /// <returns></returns>
        public async Task<T> GetAppSettingsAsync<T>(string key, string configPath = "siteconfig.json") where T : class, new()
        {
            IConfiguration config = new ConfigurationBuilder()
                .Add(new JsonConfigurationSource { Path = configPath, ReloadOnChange = true })
                .Build();

            var appconfig = new ServiceCollection()
                .AddOptions()
                .Configure<T>(config.GetSection(key))//需添加扩展类 Microsoft.Extensions.Options.ConfigurationExtensions （Install-Package Microsoft.Extensions.Options.ConfigurationExtensions）
                .BuildServiceProvider()
                .GetService<IOptions<T>>()
                .Value;

            return await Task.Run(() => appconfig);
        }
    }
}
