using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ListIT.Data.Common.Enums;
using ListIT.Data.Models;
using ListIT.Services.Data.FileService;
using ListIT.Services.Data.UserService;
using ListIT.Services.Mapping;
using ListIT.Web.ViewModels.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ListiIT.Web.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IUserService userService;
        private readonly IFileService fileService;

        public IndexModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IUserService userService,
            IFileService fileService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            this.userService = userService;
            this.fileService = fileService;
        }

        public UserDetailModel UserModel { get; set; }
        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public UserUpdateModel Input { get; set; }

        private async Task LoadAsync(User user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;

            Input = user.To<UserUpdateModel>();
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.Users
                .Include(x => x.Reviews)
                .ThenInclude(x=>x.Place)
                .FirstOrDefaultAsync(x => x.UserName == User.Identity.Name);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            this.UserModel = user.To<UserDetailModel>();
            
            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (this.Input.Image != null)
            {
               var imageUrl = await this.fileService.UploadFile(this.Input.Image, FileType.UserFile);
                this.Input.ImageUrl = imageUrl;
            }
            var user = await this.userService.UpdateUser(this.Input, this.User.Identity.Name);

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
