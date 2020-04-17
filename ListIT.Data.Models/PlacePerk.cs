using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ListIT.Data.Models
{
    public class PlacePerk
    {
        public string PlaceId { get; set; }
        public Place Place { get; set; }
        public string PerkId { get; set; }
        public Perk Perk { get; set; }

    }
}
