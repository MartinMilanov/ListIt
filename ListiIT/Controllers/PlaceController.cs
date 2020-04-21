
using ListIT.Data.Common.Enums;
using ListIT.Data.Models;
using ListIT.Services.Data.FileService;
using ListIT.Services.Data.PlaceServices;
using ListIT.Web.ViewModels.PlaceModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListiIT.Web.Controllers
{
    [Authorize]
    public class PlaceController : Controller
    {
        private readonly IPlaceService placeService;
        private readonly UserManager<User> userManager;
        private readonly IFileService fileService;

        public PlaceController(IPlaceService placeService,UserManager<User> userManager,
            IFileService fileService)
        {
            this.placeService = placeService;
            this.userManager = userManager;
            this.fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> Listing(string city, string searchWord)
        {
            var input = new PlaceFilterInputModel()
            {
                Take = 4,
                Skip = 0,
                City = city,
                SearchWord = searchWord
            };

            this.ViewData["searchWord"] = searchWord;
            this.ViewData["city"] = city;

            var listing = await this.placeService.GetPlaces(input);

            return this.View(listing);
        }


        [HttpGet]
        public async Task<IActionResult> ById(string id)
        {
            var place = await this.placeService.GetById(id);
            return this.View(place);
        }

        [HttpGet]
        public IActionResult CreatePlace()
        {
            return this.View();
        }
        [HttpPost]
        public async Task<IActionResult> CreatePlace(PlaceInputModel input)
        {
            var fileString = new StringBuilder();
            foreach (var file in input.Files)
            {
                var fileName = await this.fileService.UploadFile(file, FileType.PlaceFile);
                fileString.Append(fileName + " // ");
            }

            input.ImageUrls = fileString.ToString();
            input.CreatorId = userManager.GetUserId(this.User);
            var placeId = await this.placeService.AddPlace(input);

            return this.RedirectToAction(nameof(this.ById), new { id = placeId });
        }

        [HttpPost]
        public async Task<ActionResult<ICollection<PlaceListModel>>> GetPlaces(PlaceFilterInputModel input)
        {
            var result = await this.placeService.GetPlaces(input);

            return Ok(result);
        }
    }
}
