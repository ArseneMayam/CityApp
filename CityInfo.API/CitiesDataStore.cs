using CityInfo.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API
{
    public class CitiesDataStore
    {
        public static CitiesDataStore Current { get; } = new CitiesDataStore();
        public List<City> Cities { get; set; }
         
        public CitiesDataStore()
        {
            Cities = new List<City>()
            {
                new City(){
                    Id = 1,
                    Name = "New York",
                    Description ="The one with that big park",
                    PointsOfInterests = new List<PointOfInterest>()
                    {
                        new PointOfInterest()
                        {
                            Id = 1,
                            Name = "Central Park",
                            Description = "A description"
                        }
                        ,new PointOfInterest()
                        {
                            Id = 2,
                            Name = "Empire State",
                            Description = "A description"
                        },
                    }
                },
                 new City(){
                    Id = 2,
                    Name = "Antwerp",
                    Description ="The one with that big park",
                    PointsOfInterests = new List<PointOfInterest>()
                    {
                        new PointOfInterest()
                        {
                            Id = 1,
                            Name = "Central Park",
                            Description = "A description"
                        }
                        ,new PointOfInterest()
                        {
                            Id = 2,
                            Name = "Empire State",
                            Description = "A description"
                        },
                    }
                },
                 new City(){
                    Id = 3,
                    Name = "Paris",
                    Description ="The one with that big park",
                    PointsOfInterests = new List<PointOfInterest>()
                    {
                        new PointOfInterest()
                        {
                            Id = 1,
                            Name = "Central Park",
                            Description = "A description"
                        }
                        ,new PointOfInterest()
                        {
                            Id = 2,
                            Name = "Empire State",
                            Description = "A description"
                        },
                    }
                },
 
            };
        }
    }
}
