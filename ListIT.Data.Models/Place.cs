using ListIT.Data.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListIT.Data.Models
{
    public class Place
    {
        public Place()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Reviews = new HashSet<Review>();
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string WebsiteName { get; set; }
        public string TelephoneNumber { get; set; }
        public string OpensAt { get; set; }
        public string ClosesAt { get; set; }
        public PriceRange PriceRange { get; set; }
        public double Rating => Reviews.Count == 0 ? 0 : Reviews.Average(x => x.Rating);
        public string CreatorId { get; set; }
        public User Creator { get; set; }

        public ICollection<Review> Reviews { get; set; }
    }
}
