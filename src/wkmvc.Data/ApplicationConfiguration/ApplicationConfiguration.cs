namespace wkmvc.Data
{
    /// <summary>
    /// Describe：网站配置类
    /// Author：YuanGang
    /// Date：2016/08/04
    /// Blogs:http://www.cnblogs.com/yuangang
    /// </summary>
    public class ApplicationConfiguration
    {
        #region 属性成员

        /// <summary>
        /// 数据库选择
        /// </summary>
        public string DataBase { get; set; }
        /// <summary>
        /// 是否使用 Redis
        /// </summary>
        public bool UseRedis { get; set; }
        /// <summary>
        /// Redis 连接
        /// </summary>
        public string Redis_ConnectionString { get; set; }
        /// <summary>
        /// Redis 实例名称
        /// </summary>
        public string Redis_InstanceName { get; set; }
        /// <summary>
        /// 文件上传路径
        /// </summary>
        public string FileUpPath { get; set; }
        /// <summary>
        /// 是否启用单用户登录
        /// </summary>
        public bool IsSingleLogin { get; set; }
        /// <summary>
        /// 允许上传的文件格式
        /// </summary>
        public string AttachExtension { get; set; }
        /// <summary>
        /// 图片上传最大值KB
        /// </summary>
        public int AttachImagesize { get; set; }
        /// <summary>
        /// 视频上传最大值KB
        /// </summary>
        public int AttachVideosize { get; set; }
        /// <summary>
        /// 文档上传最大值KB
        /// </summary>
        public int AttachDocmentsize { get; set; }
        /// <summary>
        /// 文件上传最大值KB
        /// </summary>
        public int AttachFilesize { get; set; }
        /// <summary>
        /// 水印方式1文字2图片
        /// </summary>
        public int WatermarkType { get; set; }
        /// <summary>
        /// 水印文字
        /// </summary>
        public string WatermarkText { get; set; }
        /// <summary>
        /// 水印位置
        /// </summary>
        public int WatermarkPosition { get; set; }
        /// <summary>
        /// 水印质量
        /// </summary>
        public int WatermarkImgQuality { get; set; }
        /// <summary>
        /// 水印字体
        /// </summary>
        public string WatermarkFont { get; set; }
        /// <summary>
        /// 水印文字大小
        /// </summary>
        public int WatermarkFontsize { get; set; }
        /// <summary>
        /// 水印图片
        /// </summary>
        public string WatermarkPic { get; set; }
        /// <summary>
        /// 水印图片透明度
        /// </summary>
        public int WatermarkTransparency { get; set; }
        /// <summary>
        /// 缩略图宽度PX
        /// </summary>
        public int ThumbnailWidth { get; set; }
        /// <summary>
        /// 缩略图高度PX
        /// </summary>
        public int ThumbnailHeight { get; set; }
        /// <summary>
        /// 压缩文件密码
        /// </summary>
        public string ZipPassword { get; set; }

        #endregion
    }
}
