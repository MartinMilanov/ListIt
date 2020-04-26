using ListIT.Data.Models;
using ListIT.Services.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ListIT.Web.ViewModels.Reviews
{
    public class ReviewInputModel:IMapTo<Review>
    {
        [Required]
        [MaxLength(30)]
        [MinLength(10)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        [MinLength(20)]
        public string Description { get; set; }
        [Required]
        [Range(1,8)]
        public int Rating { get; set; }
        [Required]
        public string CreatorId { get; set; }
        [Required]
        public string PlaceId { get; set; }
    }
}
