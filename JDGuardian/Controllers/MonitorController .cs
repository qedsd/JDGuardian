using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace JDGuardian.Controllers
{
    /// <summary>
    /// 监控控制器
    /// </summary>
    [ApiController]
    [Route("monitor")]
    [EnableCors("AllowCors")]
    public class MonitorController : Controller
    {
        /// <summary>
        /// 添加库存监控
        /// </summary>
        /// <param name="mail">通知邮箱</param>
        /// <param name="span">间隔，单位：秒</param>
        /// <param name="skuid">商品id</param>
        /// <param name="area">区域 格式示例：19_1601_50258_51885</param>
        /// <returns>操作索引id</returns>
        [Route("addStock")]
        [HttpGet]
        public string Get(string mail, int span, long skuid, string area)
        {
            return Services.StockMonitorService.AddStockMonitor(mail,span, skuid, area);
        }

        /// <summary>
        /// 删除监控的物品
        /// </summary>
        /// <param name="id">添加监控时返回的id</param>
        /// <returns></returns>
        [Route("deleteStock")]
        [HttpDelete]
        public bool Del(string id)
        {
            return Services.StockMonitorService.TryDelMonitor(id);
        }

        /// <summary>
        /// 获取所有库存监控项
        /// </summary>
        /// <returns></returns>
        [Route("stockMonitorList")]
        [HttpGet]
        public Dictionary<string, Models.MonitorItem> GetList()
        {
            return Services.StockMonitorService.Monitors;
        }
    }
}
