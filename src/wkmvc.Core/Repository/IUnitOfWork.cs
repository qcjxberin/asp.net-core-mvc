using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wkmvc.Core
{
    /// <summary>
    /// Describe：工作单元接口
    /// Author：YuanGang
    /// Date：2016/07/16
    /// Blogs:http://www.cnblogs.com/yuangang
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// 提交
        /// </summary>
        /// <returns></returns>
        bool Commit();

        /// <summary>
        /// 异步提交
        /// </summary>
        /// <returns></returns>
        Task<bool> CommitAsync();
    }
}
