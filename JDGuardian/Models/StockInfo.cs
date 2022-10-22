using Newtonsoft.Json;

namespace JDGuardian.Models
{
	/// <summary>
	/// 库存
	/// </summary>
	public class StockInfo
    {
		public DeliveryInfo DeliveryInfo { get; set; }
		public string IsPlus { get; set; }
		public string Code { get; set; }
		/// <summary>
		/// 具体的配送时间
		/// 如：23:10前下单，预计明天(09月14日)送达
		/// </summary>
		public string PromiseResult { get; set; }
		/// <summary>
		/// 配送、售后之类的服务信息
		/// 如：由京东发货，微软京东自营官方旗舰店提供售后服务
		/// </summary>
		public string ServiceInfo { get; set; }
		/// <summary>
		/// 库存描述
		/// 如：有货
		/// </summary>
		public string StockDesc { get; set; }
		public string WeightValue { get; set; }
		public string FxgCode { get; set; }
		public string Is7ToReturn { get; set; }
		/// <summary>
		/// 库存状态码
		/// 33:有货 34:无货
		/// </summary>
		public int StockState { get; set; }
		[JsonProperty(PropertyName = "stockInfo")]
		public StockInfoSub StockInfoSub { get; set; }
		public string SupportHKMOShip { get; set; }
		public string IsStock { get; set; }
	}
}
