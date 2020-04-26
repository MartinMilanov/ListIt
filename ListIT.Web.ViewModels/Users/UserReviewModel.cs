using AutoMapper;
using ListIT.Data.Models;
using ListIT.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListIT.Web.ViewModels.Users
{
    public class UserReviewModel:IMapFrom<User>,IHaveCustomMappings
    {
        public string UserName { get; set; }
        public string ImageUrl { get; set; }
        public int ReviewCount { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<User, UserReviewModel>()
                .ForMember(x => x.ReviewCount, opt => opt.MapFrom(x => x.Reviews.Count));
        }
    }
}
