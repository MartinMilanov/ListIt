
using ListIT.Data.Models;
using ListIT.Services.Data.PlaceServices;
using ListIT.Web.ViewModels.PlaceModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListiIT.Web.Controllers
{
    [Authorize]
    public class PlaceController : Controller
    {
        private readonly IPlaceService placeService;
        private readonly UserManager<User> userManager;

        public PlaceController(IPlaceService placeService,UserManager<User> userManager)
        {
            this.placeService = placeService;
            this.userManager = userManager;
        }
        [HttpGet]
        public IActionResult CreatePlace()
        {
            return this.View();
        }
        [HttpPost]
        public async Task<IActionResult> CreatePlace(PlaceInputModel input)
        {
            input.CreatorId = userManager.GetUserId(this.User);
            await this.placeService.AddPlace(input);

            return this.Redirect("/");
        }
    }
}
