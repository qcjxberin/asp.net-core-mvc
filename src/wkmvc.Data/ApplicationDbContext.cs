using Microsoft.EntityFrameworkCore;
using wkmvc.Data.Models;

namespace wkmvc.Data
{
    /// <summary>
    /// Describe：数据上下文
    /// Author：YuanGang
    /// Date：2016/07/16
    /// Blogs:http://www.cnblogs.com/yuangang
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// 系统管理员
        /// </summary>
        public DbSet<SYS_USER> SYS_USER { get; set; }
        /// <summary>
        /// 管理员在线状态
        /// </summary>
        public DbSet<SYS_USER_ONLINE> SYS_USER_ONLINE { get; set; }
        /// <summary>
        /// 系统模块
        /// </summary>
        public DbSet<SYS_MODULE> SYS_MODULE { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {            
            base.OnModelCreating(builder);
        }
    }
}
