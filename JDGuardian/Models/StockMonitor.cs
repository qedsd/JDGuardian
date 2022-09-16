namespace JDGuardian.Models
{
    public class StockMonitor : MonitorItem
    {
        public StockMonitor(int span, long skuid, string area) : base(span, skuid, area)
        {

        }

        public override void Check()
        {
            base.Check();
            var ware = Models.WareBusiness.Creat(SkuId, Area);
            if (ware != null)
            {
                if(ware.IsStock())
                {
                    //todo:通知
                }
                else
                {
                    //todo:通知
                }
            }
        }
    }
}
