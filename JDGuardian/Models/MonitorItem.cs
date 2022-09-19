namespace JDGuardian.Models
{
    public abstract class MonitorItem
    {
        public MonitorItem(string mail, int span, long skuid,string area)
        {
            Mail = mail;
            Span = span;
            SkuId = skuid;
            Area = area;
            CreateTime = DateTime.Now;
            LastTime = DateTime.Now;
            Id = Guid.NewGuid().ToString();
            Span = span;
            RemainTime = span;
        }
        public string Mail { get; set; }
        /// <summary>
        /// 索引id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 商品id
        /// </summary>
        public long SkuId { get; set; }
        /// <summary>
        /// 区域id组合
        /// </summary>
        public string Area { get; set; }
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 间隔时间
        /// 单位：秒
        /// </summary>
        public int Span { get; set; }
        /// <summary>
        /// 上一次执行时间
        /// </summary>
        public DateTime LastTime { get; set; }
        /// <summary>
        /// 距离下一次执行时间
        /// 单位：秒
        /// </summary>
        public int RemainTime { get; set; }
        /// <summary>
        /// 监控类型
        /// </summary>
        public Enums.MonitorType MonitorType { get; set; }
        /// <summary>
        /// 执行检查
        /// </summary>
        public virtual void Check()
        {
            LastTime = DateTime.Now;
            RemainTime = Span;
        }
        /// <summary>
        /// 更新RemainTime
        /// </summary>
        public void Update()
        {
            RemainTime = Span - (int)(DateTime.Now - LastTime).TotalSeconds;
        }
        /// <summary>
        /// 是否需要执行检查
        /// </summary>
        /// <returns></returns>
        public bool IsTime()
        {
            return RemainTime <= 0;
        }
    }
}
