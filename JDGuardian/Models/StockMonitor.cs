namespace JDGuardian.Models
{
    public class StockMonitor : MonitorItem
    {
        public StockMonitor(string mail, int span, long skuid, string area) : base(mail,span, skuid, area)
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
                    string content = $"{DateTime.Now}:{SkuId}({Id})有货";
                    Console.WriteLine(content);
                    Helpers.MailHelper.SendMail(Mail,content);
                }
                else
                {
                    string content = $"{DateTime.Now}:{SkuId}({Id})无货";
                    Console.WriteLine(content);
                }
            }
        }
    }
}
