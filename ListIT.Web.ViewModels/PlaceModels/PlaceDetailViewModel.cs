﻿using ListIT.Data.Common.Enums;
using ListIT.Data.Models;
using ListIT.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListIT.Web.ViewModels.PlaceModels
{
    public class PlaceDetailViewModel:IMapFrom<Place>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string WebsiteName { get; set; }
        public string TelephoneNumber { get; set; }
        public string OpensAt { get; set; }
        public string ClosesAt { get; set; }
        public string ImageUrls { get; set; }
        public PriceRange PriceRange { get; set; }
        public double Rating => Reviews.Count == 0 ? 0 : Reviews.Average(x => x.Rating);
        public string CreatorId { get; set; }
        public User Creator { get; set; }

        public ICollection<Review> Reviews { get; set; }
    }
}
