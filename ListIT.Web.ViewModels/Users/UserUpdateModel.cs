using ListIT.Data.Models;
using ListIT.Services.Mapping;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ListIT.Web.ViewModels.Users
{
    public class UserUpdateModel:IMapFrom<User>
    {
        [MaxLength(30)]
        public string Name { get; set; }

        [MaxLength(120)]
        public string Description { get; set; }

        public IFormFile Image { get; set; }
        public string ImageUrl { get; set; }

        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        public string FacebookProfile { get; set; }

        public string TwitterProfile { get; set; }
        public string InstagramProfile { get; set; }
    }
}
