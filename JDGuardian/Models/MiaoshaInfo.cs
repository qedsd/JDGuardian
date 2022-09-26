namespace JDGuardian.Models
{
	/// <summary>
	/// 秒杀
	/// </summary>
    public class MiaoshaInfo
    {
		/// <summary>
		/// 正在秒杀时才有
		/// 图片url
		/// </summary>
		public string BannerUrl { get; set; }
		/// <summary>
		/// 即将开始秒杀时才有，表示什么时候开始
		/// 如：9月15日 00:00
		/// </summary>
		public string BenifitText { get; set; }
		public long EndTime { get; set; }
		public bool Miaosha { get; set; }
		/// <summary>
		/// 如果已经开始，则为秒杀结束剩余秒数
		/// 如果未开始，则为秒杀开始剩余秒数
		/// </summary>
		public int MiaoshaRemainTime { get; set; }
		/// <summary>
		/// 距离开始还剩
		/// 距离结束
		/// </summary>
		public string MsTrailer { get; set; }
		/// <summary>
		/// 原价
		/// </summary>
		public double OriginPrice { get; set; }
		/// <summary>
		/// 秒杀价
		/// </summary>
		public double PromoPrice { get; set; }
		/// <summary>
		/// 未知
		/// 秒杀中、即将秒杀都是1
		/// </summary>
		public int SeckillType { get; set; }
		public long StartTime { get; set; }
		/// <summary>
		/// 1 即将秒杀
		/// 2 秒杀中
		/// </summary>
		public int State { get; set; }
		/// <summary>
		/// 秒杀预告
		/// 京东秒杀
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// 扩展字段
		/// 将StartTime以DateTime表示
		/// </summary>
		public DateTime StartTime2
        {
			get => GetStartTime();
        }
		/// <summary>
		/// 扩展字段
		/// 将EndTime以DateTime表示
		/// </summary>
		public DateTime EndTime2
        {
			get => GetEndTime();
        }
		/// <summary>
		/// 扩展字段
		/// 将MiaoshaRemainTime以字符串表示
		/// 如：1天1小时1分、1小时1分、1分1秒、1秒
		/// </summary>
		public string MiaoshaRemainTime2
        {
			get => GetRemainTime();
        }

		public DateTime GetStartTime()
        {
			return Helpers.TimeHelper.UnixToDateTime(StartTime);
        }

		public DateTime GetEndTime()
		{
			return Helpers.TimeHelper.UnixToDateTime(EndTime);
		}
		/// <summary>
		/// 获取剩余时间字符串表达式
		/// 如：1天1小时1分、1小时1分、1分1秒、1秒
		/// </summary>
		/// <returns></returns>
		public string GetRemainTime()
        {
			var timeSpan = TimeSpan.FromSeconds(MiaoshaRemainTime);
			if(timeSpan.Days > 0)
            {
				return $"{timeSpan.Days}天{timeSpan.Hours}小时{timeSpan.Minutes}分";
            }
			else if(timeSpan.Hours > 0)
            {
				return $"{timeSpan.Hours}小时{timeSpan.Minutes}分";
			}
			else if(timeSpan.Minutes > 0)
            {
				return $"{timeSpan.Minutes}分{timeSpan.Seconds}秒";
			}
			else
            {
				return $"{timeSpan.Seconds}秒";
			}
		}

		/// <summary>
		/// 是否秒杀中
		/// </summary>
		/// <returns></returns>
		public bool IsMiaoshaing()
        {
			return State == 2;
        }
		/// <summary>
		/// 是否即将秒杀
		/// </summary>
		/// <returns></returns>
		public bool IsWillMiaosha()
		{
			return State == 1;
		}
	}
}
