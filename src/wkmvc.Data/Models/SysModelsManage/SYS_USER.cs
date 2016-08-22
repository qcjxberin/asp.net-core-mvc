using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wkmvc.Data.Models
{
    /// <summary>
    /// Describe：系统管理员
    /// Author：YuanGang
    /// Date：2016/07/16
    /// Blogs:http://www.cnblogs.com/yuangang
    /// </summary>
    public class SYS_USER
    {

        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int ID { get; set; }
        [MaxLength(10)]
        [Display(Name = "用户姓名")]
        public string UserName { get; set; }
        [Required]
        [MaxLength(20)]
        [Display(Name = "登录账号")]
        public string Account { get; set; }
        [Required]
        [MaxLength(1000)]
        [Display(Name = "登录密码")]
        public string Password { get; set; }
        [Required]
        [Display(Name = "是否允许登录")]
        public bool IsCanLogin { get; set; }
        [MaxLength(20)]
        [Display(Name = "英文名")]
        public string EN_Name { get; set; }
        [MaxLength(10)]
        [Display(Name = "英文名（简）")]
        public string EN_Nme_Simple { get; set; }
        [Required]
        [MaxLength(20)]
        [Display(Name = "创建者")]
        public string CreateUser { get; set; }
        [Required]
        [Display(Name = "创建时间")]
        public DateTime CreateDate { get; set; }
        [Required]
        [MaxLength(20)]
        [Display(Name = "更新人")]
        public string UpdateUser { get; set; }
        [Required]
        [Display(Name = "更新时间")]
        public DateTime UpdateDate { get; set; }
        [Required]
        [Display(Name = "是否为超级管理员")]
        public bool IsSuper { get; set; }

        /// <summary>
        /// 用户在线状态
        /// </summary>
        public SYS_USER_ONLINE UserOnline { get; set; }

    }
}
