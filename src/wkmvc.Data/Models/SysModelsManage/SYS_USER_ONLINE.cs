using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace wkmvc.Data.Models
{
    /// <summary>
    /// Describe：管理员在线状态
    /// Author：YuanGang
    /// Date：2016/08/01
    /// Blogs:http://www.cnblogs.com/yuangang
    /// </summary>
    public class SYS_USER_ONLINE
    {
        [Key,ForeignKey("SYS_USER")]
        [Display(Name = "用户ID")]
        public int UserID { get; set; }
        [MaxLength(36)]
        [Display(Name = "连接ID")]
        public string ConnectId { get; set; }
        [Display(Name = "上线时间")]
        public DateTime OnlineDate { get; set; }
        [Display(Name = "离线时间")]
        public DateTime OffLineDate { get; set; }
        [Required]
        [Display(Name = "是否在线")]
        public bool IsOnlie { get; set; }
        [MaxLength(20)]
        [Display(Name = "登录IP")]
        public string UserIP { get; set; }

    }
}
