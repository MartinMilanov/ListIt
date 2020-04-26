using ListIT.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;
using ListIT.Data.Models;
using ListIT.Web.ViewModels.Users;

namespace ListIT.Web.ViewModels.Reviews
{
    public class ReviewListModel:IMapFrom<Review>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Rating { get; set; }
        public DateTime CreatedOn { get; set; }
        public UserReviewModel Creator { get; set; }

    }
}
