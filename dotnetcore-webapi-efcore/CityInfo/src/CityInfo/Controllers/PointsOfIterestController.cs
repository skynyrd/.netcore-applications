using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityInfo.Models;
using CityInfo.RequestModels;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;


namespace CityInfo.Controllers
{
    [Route("api/cities")]
    public class PointsOfIterestController : Controller
    {
        [HttpGet("{cityId}/pointsofinterest")]
        public IActionResult GetPointsOfInterestByCityId(int cityId)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            return Ok(city.PointsOfInterest);
        }

        [HttpGet("{cityId}/pointofinterest/{pId}", Name = "GetPointOfInterestForCity")]
        public IActionResult GetPointsOfInterestByCityId(int cityId, int pId)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            var pointOfInterest = city.PointsOfInterest.FirstOrDefault(p => p.Id == pId);

            if (pointOfInterest == null)
            {
                return NotFound();
            }

            return Ok(pointOfInterest);
        }

        [HttpPost("{cityId}/pointOfInterest")]
        public IActionResult CreatePointOfInterestForCity(int cityId,
            [FromBody] CreatePointOfInterestRequestModel requestModel)
        {
            if (requestModel == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var city = CitiesDataStore.Current.Cities.SingleOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            var maxPointOfInterestId = CitiesDataStore.Current.Cities.SelectMany(c => c.PointsOfInterest).Max(p => p.Id);

            var finalPointOfInterest = new PointOfInterestDto()
            {
                Id = ++maxPointOfInterestId,
                Name = requestModel.Name,
                Description = requestModel.Description
            };

            city.PointsOfInterest.Add(finalPointOfInterest);

            return CreatedAtRoute("GetPointOfInterestForCity", new {cityId, pId = finalPointOfInterest.Id}, finalPointOfInterest);
        }

        [HttpPut("{cityId}/pointOfInterest/{id}")]
        public IActionResult UpdatePointOfInterest(int cityId, int id,
            [FromBody] UpdatePointOfInterestRequestModel requestModel)
        {
            if (requestModel == null)
            {
                return BadRequest();
            }

            if (requestModel.Description == requestModel.Name)
            {
                ModelState.AddModelError("Description", "Description should be different than name.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var city = CitiesDataStore.Current.Cities.SingleOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            var pointOfInterest = city.PointsOfInterest.FirstOrDefault(p => p.Id == id);

            if (pointOfInterest == null)
            {
                return NotFound();
            }

            pointOfInterest.Name = requestModel.Name;
            pointOfInterest.Description = requestModel.Description;

            return Ok();
        }

        /* 
         Request Body Example for Patch:
          [
	            {
  		            "op" : "replace",
  		            "path" : "name",
  		            "value" : "Updated - Central Park"
	            }
           ]
         */

        [HttpPatch("{cityId}/pointOfInterest/{id}")]
        public IActionResult PartiallyUpdatePointOfInterest(int cityId, int id,
            [FromBody] JsonPatchDocument<UpdatePointOfInterestRequestModel> requestedPatch)
        {
            if (requestedPatch == null)
            {
                BadRequest();
            }

            var city = CitiesDataStore.Current.Cities.SingleOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            var pointOfInterest = city.PointsOfInterest.FirstOrDefault(p => p.Id == id);

            if (pointOfInterest == null)
            {
                return NotFound();
            }

            var pointOfInterestToBePatched = new UpdatePointOfInterestRequestModel()
            {
                Description = pointOfInterest.Description,
                Name = pointOfInterest.Name
            };

            requestedPatch.ApplyTo(pointOfInterestToBePatched, ModelState);

            TryValidateModel(pointOfInterestToBePatched);

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            pointOfInterest.Name = pointOfInterestToBePatched.Name;
            pointOfInterest.Description = pointOfInterestToBePatched.Description;

            return NoContent();
        }
    }
}
