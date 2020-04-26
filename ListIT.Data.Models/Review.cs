using System;
using System.Collections.Generic;
using System.Text;

namespace ListIT.Data.Models
{
    public class Review
    {
        public Review()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedOn = DateTime.UtcNow;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Rating { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatorId { get; set; }
        public User Creator { get; set; }
        public string PlaceId { get; set; }
        public Place Place { get; set; }

    }
}
