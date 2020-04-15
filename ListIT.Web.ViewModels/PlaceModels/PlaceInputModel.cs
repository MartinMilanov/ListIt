using ListIT.Data.Common.Enums;
using ListIT.Data.Models;
using ListIT.Services.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ListIT.Web.ViewModels.PlaceModels
{
    public class PlaceInputModel:IMapTo<Place>,IMapFrom<Place>
    {
        [Required]
        [MaxLength(100,ErrorMessage="Name cannot be more than 100 characters")]
        public string Name { get; set; }
        [Required]
        [MaxLength(300, ErrorMessage = "Description cannot be more than 300 characters")]
        public string Description { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "City name cannot be more than 100 characters")]
        public string City { get; set; }
        [Required]
        [MaxLength(200, ErrorMessage = "Address cannot be more than 200 characters")]
        public string Address { get; set; }
        [Required]
        [Phone]
        public string TelephoneNumber { get; set; }

        public string WebsiteName { get; set; }

        [Required]
        public string OpensAt { get; set; }
        [Required]
        public string ClosesAt { get; set; }
        [Required]
        public PriceRange PriceRange { get; set; }

        public string CreatorId { get; set; }
    }
}
