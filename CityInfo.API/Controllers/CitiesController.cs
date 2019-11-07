using CityInfo.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CityInfo.API.Controllers
{
    [Route("api/cities")]
    public class CitiesController : Controller
    {
        [HttpGet()]
        public IActionResult GetCities()
        {
            return Ok(CitiesDataStore.Current.Cities);
        }
        [HttpGet("{id}")]
        public IActionResult GetCity(int id)
        {
            var city = CitiesDataStore.Current.Cities.Find(c => c.Id == id);
            if(city == null)
            {
                Console.WriteLine("In not found");
                return NotFound();
            }
            return Ok(city);
        }
    }
}
