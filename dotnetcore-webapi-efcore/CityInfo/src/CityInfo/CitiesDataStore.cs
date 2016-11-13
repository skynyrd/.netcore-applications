using System.Collections.Generic;
using CityInfo.Models;

namespace CityInfo
{
    public class CitiesDataStore
    {
        public static CitiesDataStore Current { get; } = new CitiesDataStore();

        public List<CityDto> Cities { get; set; }

        public CitiesDataStore()
        {
            Cities = new List<CityDto>
            {
                new CityDto
                {
                    Id = 1,
                    Name = "San Diego",
                    Description = "South Western",
                    PointsOfInterest = new List<PointOfInterestDto>
                    {
                        new PointOfInterestDto
                        {
                            Id = 1,
                            Name = "Statue of Liberty",
                            Description = "Kliche"
                        },
                        new PointOfInterestDto
                        {
                            Id = 2,
                            Name = "Times Square",
                            Description = "Yet another kliche"
                        }
                    }
                },
                new CityDto
                {
                    Id = 2,
                    Name = "Leeds",
                    Description = "British",
                    PointsOfInterest = new List<PointOfInterestDto>
                    {
                        new PointOfInterestDto
                        {
                            Id = 1,
                            Name = "City Center",
                            Description = "Cool place"
                        }
                    }
                },
                new CityDto
                {
                    Id = 3,
                    Name = "Bingol",
                    Description = "Eastern",
                    PointsOfInterest = new List<PointOfInterestDto>
                    {
                        new PointOfInterestDto
                        {
                            Id = 1,
                            Name = "Koy meydani",
                            Description = "Deli fisek"
                        }
                    }
                }
            };
        }
    }
}