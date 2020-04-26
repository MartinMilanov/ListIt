using ListIT.Data;
using ListIT.Data.Models;
using ListIT.Services.Mapping;
using ListIT.Web.ViewModels.PlaceModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListIT.Services.Data.PlaceServices
{
    public class PlaceService : IPlaceService
    {
        private readonly ApplicationDbContext context;

        public PlaceService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<string> AddPlace(PlaceInputModel input)
        {
            var place = input.To<Place>();
            foreach (var perkName in input.Perks)
            {
                var perk = await context.Perks.FirstOrDefaultAsync(x => x.Name == perkName);
                context.PlacePerks.Add(new PlacePerk()
                {
                    Place = place,
                    Perk = perk
                });
            }
            await this.context.AddAsync(place);
            await this.context.SaveChangesAsync();

            return place.Id;
        }

        public async Task<PlaceDetailViewModel> GetById(string id)
        {
            var place = await this.context.Places
                .Include(x => x.Creator)
                .ThenInclude(x => x.Places)
                .Include(x => x.Reviews)
                .ThenInclude(x => x.Creator)
                .Include(x=>x.PlacePerks)
                .ThenInclude(x=>x.Perk)
                .FirstOrDefaultAsync(x => x.Id == id);

            return place.To<PlaceDetailViewModel>();
        }
        public async Task<ICollection<PlaceListModel>> GetPlaces(PlaceFilterInputModel input)
        {
            var query = this.context.Places
                .Include(x => x.PlacePerks)
                .ThenInclude(x => x.Perk)
                .Include(x => x.Reviews)
                .AsQueryable();

            if (!String.IsNullOrWhiteSpace(input.SearchWord))
            {
                query = query
                    .Where(x => x.Name.ToLower().Contains(input.SearchWord.ToLower()));

            }
            if (!String.IsNullOrWhiteSpace(input.City))
            {
                query = query
                    .Where(x => x.City.ToLower().Contains(input.City.ToLower()));
            }
            if (input.Category != 0)
            {
                query = query
                    .Where(x => x.Category == input.Category);
            }
            if (input.PriceRange != 0)
            {
                query = query
                    .Where(x => x.PriceRange == input.PriceRange);
            }
            if (input.Perks != null)
            {
                if(input.Perks.Count > 0)
                foreach (var item in input.Perks)
                {
                    query = query
                        .Where(x => x.PlacePerks.Any(x => x.Perk.Name == item));
                }
            }

            var listing = await query
                .Skip(input.Skip)
                .Take(input.Take)
                .To<PlaceListModel>()
                .ToListAsync();

            return listing;
        }

    }
}

