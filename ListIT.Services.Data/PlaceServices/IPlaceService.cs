﻿using ListIT.Web.ViewModels.PlaceModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ListIT.Services.Data.PlaceServices
{
    public interface IPlaceService
    {
        public Task<string> AddPlace(PlaceInputModel input);
        public Task<PlaceDetailViewModel> GetById(string id);
    }
}
