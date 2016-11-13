using Microsoft.AspNetCore.Mvc;

namespace CityInfo.Controllers
{
    public class DummyController : Controller
    {
        private readonly CityInfoContext ctx;

        public DummyController(CityInfoContext ctx)
        {
            this.ctx = ctx;
        }

        [HttpGet]
        [Route("api/test")]
        public IActionResult Test()
        {
            return Ok();
        }
    }
}
