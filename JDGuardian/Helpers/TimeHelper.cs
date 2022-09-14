namespace JDGuardian.Helpers
{
    public static class TimeHelper
    {
        /// <summary>
        /// Unix时间戳转DateTime
        /// </summary>
        /// <param name="timestamp">时间戳</param>
        /// <returns></returns>
        public static DateTime UnixToDateTime(long timestamp)
        {
            DateTime time = DateTime.MinValue;
            DateTime startTime = new DateTime(1970, 1, 1);
            if (timestamp >= 1000000000000)   //精确到毫秒
            {
                time = startTime.AddMilliseconds(timestamp);
            }
            else if (timestamp >= 1000000000)        //精确到秒
            {
                time = startTime.AddSeconds(timestamp);
            }
            return time;
        }
    }
}
