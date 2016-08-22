using wkmvc.Data;
using wkmvc.Data.Models;

namespace wkmvc.Core.ServicesImp
{
    /// <summary>
    /// Describe：系统模块操作实现类
    /// Author：YuanGang
    /// Date：2016/08/18
    /// Blogs:http://www.cnblogs.com/yuangang
    /// </summary>
    public class ModuleService : Repository<SYS_MODULE>, IServices.IModuleService
    {
        public ModuleService(ApplicationDbContext Context) : base(Context)
        {
        }
    }
}
