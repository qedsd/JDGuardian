using JDGuardian.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace JDGuardian.Controllers
{
    /// <summary>
    /// 区域控制器
    /// </summary>
    [ApiController]
    [Route("check")]
    [EnableCors("AllowCors")]
    public class CheckController : Controller
    {
        /// <summary>
        /// 是否有库存
        /// </summary>
        /// <param name="skuId">物品id</param>
        /// <param name="area">地区id组合，格式示例：19_1601_50258_51885</param>
        /// <returns></returns>
        [Route("isStock")]
        [HttpGet]
        public async Task<CheckResult> IsStock(long skuId, string area)
        {
            var ware = await Models.WareBusiness.CreatAsync(skuId, area);
            if (ware == null)
            {
                return CheckResult.CreateErro("未知物品");
            }
            else
            {
                return new CheckResult()
                {
                    Is = ware.IsStock(),
                    WareBusiness = ware
                };
            }
        }
        /// <summary>
        /// 是否在秒杀
        /// 不包括即将开始秒杀
        /// </summary>
        /// <param name="skuId">物品id</param>
        /// <param name="area">地区id组合，格式示例：19_1601_50258_51885</param>
        /// <returns></returns>
        [Route("isMiaoshaing")]
        [HttpGet]
        public async Task<CheckResult> IsMiaoshaing(long skuId, string area)
        {
            var ware = await Models.WareBusiness.CreatAsync(skuId, area);
            if (ware == null)
            {
                return CheckResult.CreateErro("未知物品");
            }
            else
            {
                return new CheckResult()
                {
                    Is = ware.IsMiaoshaing(),
                    WareBusiness = ware
                };
            }
        }
        /// <summary>
        /// 是否即将秒杀
        /// 不包括在秒杀中
        /// </summary>
        /// <param name="skuId">物品id</param>
        /// <param name="area">地区id组合，格式示例：19_1601_50258_51885</param>
        /// <returns></returns>
        [Route("isWillMiaosha")]
        [HttpGet]
        public async Task<CheckResult> IsWillMiaosha(long skuId, string area)
        {
            var ware = await Models.WareBusiness.CreatAsync(skuId, area);
            if (ware == null)
            {
                return CheckResult.CreateErro("未知物品");
            }
            else
            {
                return new CheckResult()
                {
                    Is = ware.IsWillMiaoshaing(),
                    WareBusiness = ware
                };
            }
        }
        /// <summary>
        /// 是否在预约
        /// </summary>
        /// <param name="skuId">物品id</param>
        /// <param name="area">地区id组合，格式示例：19_1601_50258_51885</param>
        /// <returns></returns>
        [Route("isYuyueing")]
        [HttpGet]
        public async Task<CheckResult> IsYuyueing(long skuId, string area)
        {
            var ware = await Models.WareBusiness.CreatAsync(skuId, area);
            if (ware == null)
            {
                return CheckResult.CreateErro("未知物品");
            }
            else
            {
                return new CheckResult()
                {
                    Is = ware.IsYuyueing(),
                    WareBusiness = ware
                };
            }
        }
    }
}
