namespace JDGuardian.Models
{
    public class CreateMonitorItem
    {
        /// <summary>
        /// 通知邮箱
        /// </summary>
        public string Mail { get; set; }
        /// <summary>
        /// 间隔
        /// </summary>
        public int Span { get; set; }
        /// <summary>
        /// 商品id
        /// </summary>
        public long SkuId { get; set; }
        /// <summary>
        /// 区域id组合
        /// </summary>
        public string Area { get; set; }
    }
}
