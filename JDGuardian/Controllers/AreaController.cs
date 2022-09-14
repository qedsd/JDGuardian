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
    [Route("area")]
    [EnableCors("AllowCors")]
    public class AreaController : Controller
    {
        /// <summary>
        /// 获取指定区域的子区域
        /// </summary>
        /// <param name="fid">指定区域id，默认-1表示获取国家及地区</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<Models.Area>> Get(int fid = -1)
        {
            string result = await Helpers.HttpHelper.GetAsync($"https://fts.jd.com/area/get?fid={fid}");
            return JsonConvert.DeserializeObject<IEnumerable<Models.Area>>(result);
        }
    }
}
