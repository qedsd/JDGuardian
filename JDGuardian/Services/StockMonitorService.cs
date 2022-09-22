namespace JDGuardian.Services
{
    public static class StockMonitorService
    {
        public static Dictionary<string,Models.MonitorItem> Monitors = new Dictionary<string, Models.MonitorItem>();
        public static string AddStockMonitor(string mail, int span, long skuid, string area)
        {
            Models.StockMonitor stockMonitor = new Models.StockMonitor(mail,span, skuid,area);
            Monitors.Add(stockMonitor.Id, stockMonitor);
            TryStartService();
            return stockMonitor.Id;
        }
        public static bool TryDelMonitor(string id)
        {
            return Monitors.Remove(id);
        }
        private static Timer MonitorTimer;
        public static void TryStartService()
        {
            if (MonitorTimer == null)
            {
                StartService();
            }
        }
        public static void StartService()
        {
            MonitorTimer = new Timer(TimerCallback,null,0,1000);
        }
        public static void TimerCallback(object state)
        {
            var items = Monitors.Values.Where(p => p.IsTime()).ToList();
            if(items.Any())
            {
                Helpers.ThreadHelper.Run(items, (p) => p.Check());
            }
            foreach(var p in Monitors.Values)
            {
                p.Update();
            }
        }
    }
}
