using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace JDGuardian.Controllers
{
    [ApiController]
    [Route("area")]
    [EnableCors("AllowCors")]
    public class AreaController : Controller
    {
        [Route("get")]
        [HttpGet]
        public async Task<IEnumerable<Models.Area>> Get(int fid = -1)
        {
            string result = await Helpers.HttpHelper.GetAsync($"https://fts.jd.com/area/get?fid={fid}");
            return JsonConvert.DeserializeObject<IEnumerable<Models.Area>>(result);
        }
    }
}
