using System.ComponentModel;

namespace JDGuardian.Enums
{
    public enum MonitorType
    {
        [Description("库存监控")]
        Stock,
        [Description("价格监控")]
        Pirce
    }
}
