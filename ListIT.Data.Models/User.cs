using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListIT.Data.Models
{
    public class User:IdentityUser<string>
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Places = new HashSet<Place>();
            this.Reviews = new HashSet<Review>();
        }
        public string ImageUrl { get; set; }
        public ICollection<Place> Places { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
