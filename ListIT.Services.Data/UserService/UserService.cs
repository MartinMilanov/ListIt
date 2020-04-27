using ListIT.Data;
using ListIT.Data.Models;
using ListIT.Services.Mapping;
using ListIT.Web.ViewModels.Users;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ListIT.Services.Data.UserService
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<User> userManager;

        public UserService(ApplicationDbContext context,UserManager<User> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task<User> UpdateUser(UserUpdateModel input,string userName)
        {
            var user = await this.userManager.FindByNameAsync(userName);

            user.Name = input.Name;
            user.Description = input.Description;
            user.PhoneNumber = input.PhoneNumber;

            if (!String.IsNullOrEmpty(input.ImageUrl))
            {
                user.ImageUrl = input.ImageUrl;
            }

            user.TwitterProfile = input.TwitterProfile;
            user.FacebookProfile = input.FacebookProfile;
            user.InstagramProfile = input.InstagramProfile;

            this.context.Users.Update(user);
            await this.context.SaveChangesAsync();

            return user;
        }
    }
}
