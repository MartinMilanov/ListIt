using ListIT.Data.Models;
using ListIT.Services.Data.ReivewService;
using ListIT.Web.ViewModels.Reviews;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListiIT.Web.Controllers
{
    public class ReviewController:Controller
    {
        private readonly IReviewService reviewService;
        private readonly UserManager<User> userManager;

        public ReviewController(IReviewService reviewService, UserManager<User> userManager)
        {
            this.reviewService = reviewService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> PostReview(ReviewInputModel input)
        {
            var creatorId = this.userManager.GetUserId(this.User);
            input.CreatorId = creatorId;

            await this.reviewService.PostReview(input);

            return this.RedirectToAction("ById", "Place", new { id = input.PlaceId });
        }
    }
}
