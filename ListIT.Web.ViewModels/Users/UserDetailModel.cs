using AutoMapper;
using ListIT.Data.Models;
using ListIT.Services.Mapping;
using ListIT.Web.ViewModels.PlaceModels;
using ListIT.Web.ViewModels.Reviews;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListIT.Web.ViewModels.Users
{
    public class UserDetailModel:IMapFrom<User>,IHaveCustomMappings
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<string> SocialMedia { get; set; }
        public ICollection<ReviewListModel> Reviews { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<User, UserDetailModel>()
               .ForMember(x => x.SocialMedia, opt => opt.MapFrom(x=> new string[] { x.FacebookProfile,x.InstagramProfile,x.TwitterProfile}.ToList()));
        }
    }
}
