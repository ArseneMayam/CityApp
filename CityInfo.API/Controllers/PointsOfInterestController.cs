using CityInfo.API.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CityInfo.API.Controllers
{
    [Route("api/cities")]
    public class PointsOfInterestController : Controller
    {
        [HttpGet("{cityId}/pointsofinterest")]
        public IActionResult GetPointsOfInterest(int cityId)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if(city == null)
            {
                return NotFound();
            }
            return Ok(city.PointsOfInterests);
        }

        [HttpGet("{cityId}/pointsofinterest/{id}", Name = "GetPointOfInterest")]
        public IActionResult GetPointOfInterest(int cityId, int id)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if(city == null)
            {
                return NotFound();
            }
            var pointOfInterest = city.PointsOfInterests.FirstOrDefault(p => p.Id == id);
            if(pointOfInterest == null)
            {
                return NotFound();
            }
            return Ok(pointOfInterest);
        }

        [HttpPost("{cityId}/pointsofinterest")]
        public IActionResult CreatePointOfInterest(int cityId,
            [FromBody] PointOfInterestForCreation pointOfInterest)
        {
            if (pointOfInterest == null)
            {
                return BadRequest();
            }
            // validate input data
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }
            // demo purposes - generate id
            var maxPointOfInterestId = CitiesDataStore.Current.Cities.SelectMany(c => c.PointsOfInterests).Max(p => p.Id);
            var finalPointOfInterest = new PointOfInterest()
            {
                Id = maxPointOfInterestId++,
                Name = pointOfInterest.Name,
                Description = pointOfInterest.Description
            };

            city.PointsOfInterests.Add(finalPointOfInterest);

            return CreatedAtRoute("GetPointOfInterest", new { cityId = cityId, id = finalPointOfInterest.Id }, finalPointOfInterest);
        }

        [HttpPut("{cityId}/pointsofinterest/{id}")]
        public IActionResult UpdatePointOfInterest(int cityId, int id,
            [FromBody] PointOfInterestForUpdate pointOfInterest)
        {
            if (pointOfInterest == null)
            {
                return BadRequest();
            }
            if(pointOfInterest.Description == pointOfInterest.Name)
            {
                ModelState.AddModelError("Description", "The provided description should be different from the name");
            }
            // validate input data
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }

            var pointOfInterestFromStore = city.PointsOfInterests.FirstOrDefault(p => p.Id == id);
            if (pointOfInterestFromStore == null)
            {
                return NotFound();
            }

            pointOfInterestFromStore.Name = pointOfInterest.Name;
            pointOfInterestFromStore.Description = pointOfInterest.Description;

            return NoContent();
        }

        [HttpPatch("{cityId}/pointsofinterest{id}")]
        public IActionResult PartiallyUpdatePointOfInterest(int cityId, int id,
            [FromBody] JsonPatchDocument<PointOfInterestForUpdate> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }
          
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }
            var pointOfInterestFromStore = city.PointsOfInterests.FirstOrDefault(p => p.Id == id);
            if (pointOfInterestFromStore == null)
            {
                return NotFound();
            }

            var pointOfInterestToPatch = new PointOfInterestForUpdate()
            {
                Name = pointOfInterestFromStore.Name,
                Description = pointOfInterestFromStore.Description

            };
            patchDoc.ApplyTo(pointOfInterestToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (pointOfInterestToPatch.Description == pointOfInterestToPatch.Name)
            {
                ModelState.AddModelError("Description", "The provided description should be different from the name");
            }

            TryValidateModel(pointOfInterestToPatch);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            pointOfInterestFromStore.Name = pointOfInterestToPatch.Name;
            pointOfInterestFromStore.Description = pointOfInterestToPatch.Description;

            return NoContent();
        }
        [HttpDelete("{cityId}/pointsofinterest{id}")]
        public IActionResult DeletePointOfInterest(int cityId, int id)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }
            var pointOfInterestFromStore = city.PointsOfInterests.FirstOrDefault(p => p.Id == id);
            if (pointOfInterestFromStore == null)
            {
                return NotFound();
            }
            city.PointsOfInterests.Remove(pointOfInterestFromStore);
            return NoContent();
        }

    }
}
