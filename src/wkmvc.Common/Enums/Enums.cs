using System.Collections.Generic;
using System.ComponentModel;

namespace wkmvc.Common.Enums
{
    #region Enums 枚举独特类

    /// <summary>
    /// Describe：Enums 枚举独特类
    /// Author：YuanGang
    /// Date：2016/08/04
    /// Blogs:http://www.cnblogs.com/yuangang
    /// </summary>
    public class Enums
    {
        /// <summary>
        /// 枚举值 Value
        /// </summary>
        public int Value { get; set; }
        /// <summary>
        /// 枚举显示值 Text
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// 枚举说明 Describe
        /// </summary>
        public string Describe { get;set;}
    }

    #endregion

    #region enumOperation 系统操作枚举

    /// <summary>
    /// Describe：系统操作枚举
    /// Author：YuanGang
    /// Date：2016/08/04
    /// Blogs:http://www.cnblogs.com/yuangang
    /// </summary>
    public enum enumOperation
    {
        /// <summary>
        /// 无
        /// </summary>
        [Description("无")]
        None,
        /// <summary>
        /// 查询
        /// </summary>
        [Description("查询")]
        Select,
        /// <summary>
        /// 添加
        /// </summary>
        [Description("添加")]
        Add,
        /// <summary>
        /// 修改
        /// </summary>
        [Description("修改")]
        Edit,
        /// <summary>
        /// 移除
        /// </summary>
        [Description("移除")]
        Remove,
        /// <summary>
        /// 登录
        /// </summary>
        [Description("登录")]
        Login,
        /// <summary>
        /// 登出
        /// </summary>
        [Description("登出")]
        LogOut,
        /// <summary>
        /// 导出
        /// </summary>
        [Description("导出")]
        Export,
        /// <summary>
        /// 导入
        /// </summary>
        [Description("导入")]
        Import,
        /// <summary>
        /// 审核
        /// </summary>
        [Description("审核")]
        Audit,
        /// <summary>
        /// 回复
        /// </summary>
        [Description("回复")]
        Reply,
        /// <summary>
        /// 下载
        /// </summary>
        [Description("下载")]
        Download,
        /// <summary>
        /// 上传
        /// </summary>
        [Description("上传")]
        Upload,
        /// <summary>
        /// 分配
        /// </summary>
        [Description("分配")]
        Allocation,
        /// <summary>
        /// 文件
        /// </summary>
        [Description("文件")]
        Files,
        /// <summary>
        /// 流程
        /// </summary>
        [Description("流程")]
        Flow
    }

    #endregion

    #region enumLog4net Log4net日志枚举

    /// <summary>
    /// Describe：Log4net日志枚举
    /// Author：YuanGang
    /// Date：2016/08/04
    /// Blogs:http://www.cnblogs.com/yuangang
    /// </summary>
    public enum enumLog4net
    {
        [Description("普通")]
        INFO,
        [Description("警告")]
        WARN,
        [Description("错误")]
        ERROR,
        [Description("异常")]
        FATAL
    }

    #endregion

    #region enumModuleType 模块页面类别枚举

    /// <summary>
    /// Describe：模块页面类别枚举
    /// Author：YuanGang
    /// Date：2016/08/04
    /// Blogs:http://www.cnblogs.com/yuangang
    /// </summary>
    public enum enumModuleType
    {
        无页面 = 1,
        列表页 = 2,
        弹出页 = 3,
        跳转页 = 4
    }

    #endregion

    #region FLowEnums 流程枚举

    /// <summary>
    /// Describe：流程枚举
    /// Author：YuanGang
    /// Date：2016/08/04
    /// Blogs:http://www.cnblogs.com/yuangang
    /// </summary>
    public enum FLowEnums
    {
        /// <summary>
        /// 空白
        /// </summary>
        [Description("空白")]
        Blank = 0,
        /// <summary>
        /// 草稿
        /// </summary>
        [Description("草稿")]
        Draft = 1,
        /// <summary>
        /// 运行中
        /// </summary>
        [Description("运行中")]
        Runing = 2,
        /// <summary>
        /// 已完成
        /// </summary>
        [Description("已完成")]
        Complete = 3,
        /// <summary>
        /// 挂起
        /// </summary>
        [Description("挂起")]
        HungUp = 4,
        /// <summary>
        /// 退回
        /// </summary>
        [Description("退回")]
        ReturnSta = 5,
        /// <summary>
        /// 转发(移交)
        /// </summary>
        [Description("移交")]
        Shift = 6,
        /// <summary>
        /// 删除(逻辑删除状态)
        /// </summary>
        [Description("删除")]
        Delete = 7,
        /// <summary>
        /// 加签
        /// </summary>
        [Description("加签")]
        Askfor = 8,
        /// <summary>
        /// 冻结
        /// </summary>
        [Description("冻结")]
        Fix = 9,
        /// <summary>
        /// 批处理
        /// </summary>
        [Description("批处理")]
        Batch = 10,
        /// <summary>
        /// 加签回复状态
        /// </summary>
        [Description("加签回复")]
        AskForReplay = 11
    }

    #endregion

    #region ClsDic 系统字典

    /// <summary>
    /// Describe：系统字典
    /// Author：YuanGang
    /// Date：2016/08/04
    /// Blogs:http://www.cnblogs.com/yuangang
    /// </summary>
    public class ClsDic
    {
        /// <summary>
        /// 根据DicKey值获取value
        /// </summary>
        public static string GetDicValueByKey(string key, Dictionary<string, string> p)
        {
            if (p == null || p.Count == 0) return "";
            var dic = p.GetEnumerator();
            while (dic.MoveNext())
            {
                var obj = dic.Current;
                if (key == obj.Key)
                    return obj.Value;
            }
            return "";
        }

        /// <summary>
        /// 根据DICValue获取Key
        /// </summary>
        public static string GetDicKeyByValue(string value, Dictionary<string, string> p)
        {
            if (p == null || p.Count == 0) return "";
            var dic = p.GetEnumerator();
            while (dic.MoveNext())
            {
                var obj = dic.Current;
                if (obj.Value == value)
                    return obj.Key;
            }
            return "";
        }

        /// <summary>
        /// 实体与编码对应字典,在验证数据权限时,通过此处字典来枚举实体编号
        /// </summary>
        public static Dictionary<string, string> DicEntity
        {
            get
            {
                Dictionary<string, string> _dic = new Dictionary<string, string>();
                _dic.Add("日志", "");
                _dic.Add("用户", "18da4207-3bfc-49ea-90f7-16867721805c");
                return _dic;
            }
        }

        /// <summary>
        /// 存放特别的角色编号字典,在验证操作权限时用到
        /// </summary>
        public static Dictionary<string, int> DicRole
        {
            get
            {
                Dictionary<string, int> _dic = new Dictionary<string, int>();
                _dic.Add("超级管理员", 1);
                return _dic;
            }
        }

        /// <summary>
        /// 存放业务状态
        /// </summary>
        public static Dictionary<string, int> DicStatus
        {
            get
            {
                Dictionary<string, int> _dic = new Dictionary<string, int>();
                _dic.Add("驳回", 0);
                _dic.Add("通过", 1);
                _dic.Add("等待审核", 2);
                return _dic;
            }
        }
        
        /// <summary>
        /// 邮件发送状态
        /// </summary>
        public static Dictionary<string, int> DicMailSendStatus
        {
            get
            {
                Dictionary<string, int> _dic = new Dictionary<string, int>();
                _dic.Add("未发送", 0);
                _dic.Add("已发送", 1);
                _dic.Add("发送失败", 2);
                return _dic;
            }
        }

        /// <summary>
        /// 邮件阅读状态
        /// </summary>
        public static Dictionary<string, int> DicMailReadStatus
        {
            get
            {
                Dictionary<string, int> _dic = new Dictionary<string, int>();
                _dic.Add("未读", 0);
                _dic.Add("已读", 1);
                return _dic;
            }
        }

        /// <summary>
        /// SignalR 消息类型
        /// </summary>
        public static Dictionary<string, int> DicMessageType
        {
            get
            {
                Dictionary<string, int> _dic = new Dictionary<string, int>();
                _dic.Add("广播", 0);
                _dic.Add("组播", 1);
                _dic.Add("单播", 2);
                return _dic;
            }
        }

        /// <summary>
        /// 字典类型
        /// </summary>
        //public static Dictionary<string, string> DicCodeType
        //{
        //    get
        //    {
        //        Dictionary<string, string> _dic = new Dictionary<string, string>();
        //        try
        //        {
        //            string dicStr = Utils.GetFileContent(HttpContext, false);
        //            var diclist = dicStr.TrimEnd(',').TrimStart(',').Split(',').ToList();
        //            if (diclist.Count > 0)
        //            {
        //                foreach (var item in diclist)
        //                {
        //                    _dic.Add(item.Split('-')[0], item.Split('-')[1]);
        //                }
        //            }
        //        }
        //        catch { }
        //        return _dic;
        //    }
        //}
    }

    #endregion
}
