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
        /// <param name="item">订阅数据</param>
        /// <returns>操作索引id</returns>
        /// <remarks>
        /// Post示例:
        ///
        ///     {
        ///        "mail": "qq@qq.com",
        ///        "span": 60,
        ///        "skuId": 100016148888,
        ///        "area": "19_1601_50258_51885"
        ///     }
        ///
        /// </remarks>
        [Route("addStock")]
        [HttpPost]
        [Produces("application/json")]
        public string Post([FromBody] Models.CreateMonitorItem item)
        {
            string id =  Services.StockMonitorService.AddStockMonitor(item.Mail, item.Span, item.SkuId, item.Area);
            if(!string.IsNullOrEmpty(id))
            {
                Services.MailService.SendMail(item.Mail, "JDGuardian库存监控", $"已添加 https://item.jd.com/{item.SkuId}.html 到库存监控列表");
            }
            return id;
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
