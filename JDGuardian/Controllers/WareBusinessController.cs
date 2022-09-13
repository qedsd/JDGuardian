using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace JDGuardian.Controllers
{
    [ApiController]
    [Route("getWareBusiness")]
    [EnableCors("AllowCors")]
    public class WareBusinessController : Controller
    {
        /// <summary>
        /// 获取物品价格信息
        /// </summary>
        /// <param name="skuId">物品id</param>
        /// <param name="area">地区，格式示例：19_1601_50258_51885</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<Models.WareBusiness> Get(long skuId,string area)
        {
            string result = await Helpers.HttpHelper.GetAsync($"https://item-soa.jd.com/getWareBusiness?skuId={skuId}&area={area}");
            return JsonConvert.DeserializeObject<Models.WareBusiness>(result);
        }
    }
}
