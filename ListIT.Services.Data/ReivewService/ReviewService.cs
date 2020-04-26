using ListIT.Data;
using ListIT.Data.Models;
using ListIT.Services.Mapping;
using ListIT.Web.ViewModels.Reviews;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ListIT.Services.Data.ReivewService
{
    public class ReviewService : IReviewService
    {
        private readonly ApplicationDbContext context;

        public ReviewService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<ReviewListModel> PostReview(ReviewInputModel input)
        {
            var review = input.To<Review>();

            await this.context.Reviews.AddAsync(review);
            await this.context.SaveChangesAsync();

            var result = await this.context.Reviews
                .Include(x=>x.Creator)
                .ThenInclude(x=>x.Reviews)
                .FirstOrDefaultAsync(x=>x.Id == review.Id);

            return result.To<ReviewListModel>();

        }

    }
}
