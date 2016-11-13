using System.Linq;
using System.Net;
using CityInfo.Models;
using CityInfo.RequestModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace CityInfo.Controllers
{
     [Route("api/[controller]")]
    public class CitiesController : Controller
    {
        private readonly ILogger<CitiesController> logger;

        public CitiesController(ILogger<CitiesController> logger)
        {
            this.logger = logger;
        }

        // JsonResult => Derives from ActionResult, to response with json.
        public JsonResult GetCities()
        {
            var jsonResult = new JsonResult(CitiesDataStore.Current.Cities)
            {
                StatusCode = 200
            };

            return jsonResult;
        }

        [HttpGet("{id}")]
        public IActionResult GetCity(int id)
        {
            var city = CitiesDataStore.Current.Cities.SingleOrDefault(c => c.Id == id);

            if (city == null)
            {
                logger.LogInformation($"City with {id} could not found.");
                return NotFound();
            }

            return Ok(city);
        }
    }
}
