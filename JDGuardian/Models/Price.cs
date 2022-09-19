namespace JDGuardian.Models
{
    public class Price
    {
		public string Epp { get; set; }
		public bool HagglePromotion { get; set; }
		public long Id { get; set; }
		public double M { get; set; }
		public string Nup { get; set; }
		/// <summary>
		/// 原始价格
		/// </summary>
		public double Op { get; set; }
		/// <summary>
		/// 当前价格
		/// -1时表示不可购买，如无货、下架
		/// </summary>
		public double P { get; set; }
		/// <summary>
		/// 额外信息
		/// </summary>
		public PlusTag PlusTag { get; set; }
		public string Pp { get; set; }
		public string Sdp { get; set; }
		/// <summary>
		/// 粉丝价格
		/// </summary>
		public string Sfp { get; set; }
		public string Sp { get; set; }
		public string Tkp { get; set; }
		public string Tpp { get; set; }
	}
}
