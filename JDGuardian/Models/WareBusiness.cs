namespace JDGuardian.Models
{
    /// <summary>
    /// 物品信息
    /// </summary>
    public class WareBusiness
    {
        /// <summary>
        /// 物品基本信息
        /// </summary>
        public WareInfo WareInfo { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public Price Price { get; set; }
        /// <summary>
        /// 秒杀
        /// </summary>
        public MiaoshaInfo MiaoshaInfo { get; set; }
        /// <summary>
        /// 预约
        /// </summary>
        public YuyueInfo YuyueInfo { get; set; }
        /// <summary>
        /// 库存
        /// </summary>
        public StockInfo StockInfo { get; set; }

        public static async Task<WareBusiness> CreatAsync(long skuId, string area)
        {
            string result = await Helpers.HttpHelper.GetAsync($"https://item-soa.jd.com/getWareBusiness?skuId={skuId}&area={area}");
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Models.WareBusiness>(result);
        }

        public static WareBusiness Creat(long skuId, string area)
        {
            string result = Helpers.HttpHelper.GetAsync($"https://item-soa.jd.com/getWareBusiness?skuId={skuId}&area={area}").Result;
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Models.WareBusiness>(result);
        }

        /// <summary>
        /// 是否有货可买
        /// </summary>
        /// <returns></returns>
        public bool IsStock()
        {
            //可考虑配合https://cd.jd.com/stocks?type=getstocks&skuIds=100016148864&area=19_1601_50258_51885使用
            return Price != null && Price.P != -1 && StockInfo != null && StockInfo.StockState == 33;
        }

        /// <summary>
        /// 是否正处于秒杀
        /// </summary>
        /// <returns></returns>
        public bool IsMiaoshaing()
        {
            return MiaoshaInfo != null && MiaoshaInfo.IsMiaoshaing();
        }

        /// <summary>
        /// 是否即将秒杀
        /// </summary>
        /// <returns></returns>
        public bool IsWillMiaoshaing()
        {
            return MiaoshaInfo != null && MiaoshaInfo.IsWillMiaosha();
        }

        /// <summary>
        /// 是否处于预约
        /// </summary>
        /// <returns></returns>
        public bool IsYuyueing()
        {
            return YuyueInfo != null;
        }
    }
}
