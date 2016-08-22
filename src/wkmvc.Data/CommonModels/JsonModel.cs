namespace wkmvc.Data.CommonModels
{
    public class JsonModel
    {
        /// <summary>
        /// 数据状态
        /// </summary>
        public bool Status { get; set; }
        /// <summary>
        /// 提示信息
        /// </summary>
        public string Msg { get; set; }
        /// <summary>
        /// 回传URL
        /// </summary>
        public string ReturnUrl { get; set; }
        /// <summary>
        /// 数据包
        /// </summary>
        public object Data { get; set; }
    }
}
