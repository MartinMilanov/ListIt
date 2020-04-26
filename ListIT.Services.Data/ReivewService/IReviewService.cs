using ListIT.Web.ViewModels.Reviews;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ListIT.Services.Data.ReivewService
{
    public interface IReviewService
    {
        public Task<ReviewListModel> PostReview(ReviewInputModel input);
    }
}
