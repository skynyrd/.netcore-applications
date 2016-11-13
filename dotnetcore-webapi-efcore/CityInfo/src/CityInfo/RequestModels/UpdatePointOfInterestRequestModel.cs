﻿using System.ComponentModel.DataAnnotations;

namespace CityInfo.RequestModels
{
    public class UpdatePointOfInterestRequestModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }
    }
}
