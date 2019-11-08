using CityInfo.API.Entities;
using CityInfo.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CityInfo.API.Controllers
{
    [Route("api/cities")]
    public class CitiesController : Controller
    {
        private ICityInfoRepository cityInfoRepository;

         CitiesController(ICityInfoRepository cityInfoRepository)
        {
            this.cityInfoRepository = cityInfoRepository;
        }
        [HttpGet()]
        public IActionResult GetCities()
        {
            var cities = cityInfoRepository.GetCities();
            if(cities == null)
            {
                return NotFound();
            }
            return Ok(cities);
        }
        [HttpGet("{id}")]
        public IActionResult GetCity(int id, bool includePointsOfInterest = false)
        {
            var city = cityInfoRepository.GetCity(id,includePointsOfInterest);
            if(city == null)
            {
                return NotFound();
            }
            return null;
        }
    }
}
