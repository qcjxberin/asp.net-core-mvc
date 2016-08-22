using System;
using System.Threading;
using System.Threading.Tasks;
using wkmvc.Data;

namespace wkmvc.Core
{
    /// <summary>
    /// Describe：工作单元实现类
    /// Author：YuanGang
    /// Date：2016/07/16
    /// Blogs:http://www.cnblogs.com/yuangang
    /// </summary>
    public class UnitOfWork :IUnitOfWork, IDisposable
    {
        #region 数据上下文

        /// <summary>
        /// 数据上下文
        /// </summary>
        private ApplicationDbContext _Context;
        public UnitOfWork(ApplicationDbContext Context)
        {
            _Context = Context;
        }

        #endregion

        /// <summary>
        /// 提交
        /// </summary>
        /// <returns></returns>
        public bool Commit()
        {
            return _Context.SaveChanges() > 0;
        }
        /// <summary>
        /// 异步提交
        /// </summary>
        /// <returns></returns>
        public async Task<bool> CommitAsync()
        {
            int result = await _Context.SaveChangesAsync();
            return result > 0;
        }

        public void Dispose()
        {
            if(_Context!=null)
            {
                _Context.Dispose();
            }
            GC.SuppressFinalize(this);
        }
    }
}
