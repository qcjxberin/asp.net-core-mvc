using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wkmvc.Services.ComServices
{
    /// <summary>
    /// Describe：信息服务
    /// Author：YuanGang
    /// Date：2016/08/17
    /// Blogs:http://www.cnblogs.com/yuangang
    /// 邮件服务：
    /// WebSite：
    /// 短信服务：
    /// WebSite：
    /// </summary>
    public static class MessageServices
    {
        public static Task SendEmailAsync(string email, string subject, string message)
        {
            // Plug in your email service
            return Task.FromResult(0);
        }

        public static Task SendSmsAsync(string number, string message)
        {
            // Plug in your sms service
            return Task.FromResult(0);
        }
    }
}
