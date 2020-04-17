using System;
using System.Collections.Generic;
using System.Text;

namespace ListIT.Data.Models
{
    public class Perk
    {
        public Perk()
        {
            this.Id = Guid.NewGuid().ToString();
            this.PlacePerks = new HashSet<PlacePerk>();
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public ICollection<PlacePerk> PlacePerks { get; set; }
    }
}
