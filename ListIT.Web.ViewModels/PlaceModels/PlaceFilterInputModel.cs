using ListIT.Data.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ListIT.Web.ViewModels.PlaceModels
{
    public class PlaceFilterInputModel
    {
        [Required]
        public int Take { get; set; }
        [Required]
        public int Skip { get; set; }
        [Required]
        public string City { get; set; }
        public string SearchWord { get; set; }
        public Category Category { get; set; }
        public PriceRange PriceRange { get; set; }
        public List<string> Perks { get; set; }
    }
}
