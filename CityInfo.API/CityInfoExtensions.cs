using CityInfo.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API
{
    public static class CityInfoExtensions
    {
        public static void EnsureSeedDataForContext(this CityInfoContext context)
        {
            if (context.Cities.Any())
            {
                return;
            }
            // init seed data
            var cities = new List<City>()
            {
                new City(){                  
                    Name = "New York",
                    Description ="The one with that big park",
                    PointsOfInterests = new List<PointOfInterest>()
                    {
                        new PointOfInterest()
                        {                          
                            Name = "Central Park",
                            Description = "A description"
                        }
                        ,new PointOfInterest()
                        {                           
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
                }
            };
            context.Cities.AddRange(cities);
            context.SaveChanges();
        }
    }
}
