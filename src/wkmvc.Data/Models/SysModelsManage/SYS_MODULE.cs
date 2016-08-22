using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace wkmvc.Data.Models
{
    /// <summary>
    /// Describe：系统模块
    /// Author：YuanGang
    /// Date：2016/08/18
    /// Blogs:http://www.cnblogs.com/yuangang
    /// </summary>
    public class SYS_MODULE
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int ID { get; set; }
        [Required]
        [MaxLength(36)]
        [Display(Name = "所属系统")]
        public string SystemID { get; set; }
        [Required]
        [Display(Name = "父级ID")]
        public int ParentID { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "显示名称")]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "模块别名")]
        public string Alias { get; set; }
        [Required]
        [Display(Name = "模块类型")]
        public int ModuleType { get; set; }
        [MaxLength(50)]
        [Display(Name = "ICON图标")]
        public string Icon { get; set; }
        [MaxLength(100)]
        [Display(Name = "模块路径")]
        public string ModulePath { get; set; }       
        [Required]
        [Display(Name = "是否显示")]
        public bool IsDisplay { get; set; }
        [Required]
        [Display(Name = "显示顺序")]
        public int DisplayOrder { get; set; }
        [Required]
        [Display(Name = "模块级别")]
        public int Levels { get; set; }
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
    }
}
