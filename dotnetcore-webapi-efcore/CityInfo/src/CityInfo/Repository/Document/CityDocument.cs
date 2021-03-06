﻿using System.Collections.Generic;

namespace CityInfo.Repository.Document
{
    public class CityDocument
    {
        //[Key] is not required: EF Core auto detects key if it is named as Id or [DocumentName]Id
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberOfPointsOfInterest => PointsOfInterest.Count;

        public ICollection<PointOfInterestDocument> PointsOfInterest { get; set; } = new List<PointOfInterestDocument>();
    }
}
