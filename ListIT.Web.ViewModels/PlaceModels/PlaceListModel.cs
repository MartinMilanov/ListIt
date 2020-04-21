using AutoMapper;
using ListIT.Data.Common.Enums;
using ListIT.Data.Models;
using ListIT.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListIT.Web.ViewModels.PlaceModels
{
    public class PlaceListModel:IMapFrom<Place>,IHaveCustomMappings
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string WebsiteName { get; set; }
        public string TelephoneNumber { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int ReviewCount { get; set; }
        public double Rating { get; set; }
        public Category Category { get; set; }
        public PriceRange PriceRange { get; set; }
        public string MainImage => this.ImageUrls.Split(" // ").ToArray()[0];
        public string ImageUrls { get; set; }
        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Place, PlaceListModel>()
                .ForMember(x => x.ReviewCount, opt => opt.MapFrom(x => x.Reviews.Count));
        }
    }
}
