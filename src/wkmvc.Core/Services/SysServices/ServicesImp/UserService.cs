using wkmvc.Data;
using wkmvc.Data.Models;

namespace wkmvc.Core.ServicesImp
{
    /// <summary>
    /// Describe：管理员操作实现类
    /// Author：YuanGang
    /// Date：2016/07/16
    /// Blogs:http://www.cnblogs.com/yuangang
    /// </summary>
    public class UserService : Repository<SYS_USER>, IServices.IUserService
    {
        public UserService(ApplicationDbContext Context) : base(Context)
        {

        }
    }
}
