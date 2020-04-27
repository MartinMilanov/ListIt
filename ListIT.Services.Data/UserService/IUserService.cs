using ListIT.Data.Models;
using ListIT.Web.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ListIT.Services.Data.UserService
{
    public interface IUserService
    {
        public Task<User> UpdateUser(UserUpdateModel input,string userName);
    }
}
