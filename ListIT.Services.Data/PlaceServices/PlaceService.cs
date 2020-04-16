using ListIT.Data;
using ListIT.Data.Models;
using ListIT.Services.Mapping;
using ListIT.Web.ViewModels.PlaceModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
            await this.context.AddAsync(place);
            await this.context.SaveChangesAsync();

            return place.Id;
        }

        public async Task<PlaceDetailViewModel> GetById(string id)
        {
            var place = await this.context.Places
                .Include(x=>x.Creator)
                .ThenInclude(x=>x.Places)
                .Include(x=>x.Reviews)
                .ThenInclude(x=>x.Creator)
                .FirstOrDefaultAsync(x=>x.Id == id);

            return place.To<PlaceDetailViewModel>();
        }
    }
}
