using ListIT.Data.Common.Enums;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ListIT.Services.Data.FileService
{
    public class FileService : IFileService
    {
        private readonly IHostingEnvironment env;
        public string UserImagesPath => @"wwwroot/images/user-images";
        public string PlacesImagePath => @"wwwroot/images/place-images";
        public FileService(IHostingEnvironment env)
        {
            this.env = env;
        }
        public async Task<string> UploadFile(IFormFile file, FileType fileType)
        {

            if (file.Length > 0)
            {
                var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                var extension = Path.GetExtension(file.FileName);
                var webRootPath = env.ContentRootPath;
                fileName = DateTime.UtcNow
                           .ToString("yyyymmssfff") + fileName + extension;


                var path = fileType == FileType.PlaceFile ? Path.Combine(webRootPath, PlacesImagePath, fileName)
                    : Path.Combine(webRootPath, UserImagesPath, fileName);

                var dbUrl = fileType == FileType.PlaceFile ? "/" + "images/place-images" + "/" + fileName
                    : "/" + "images/user-images" + "/" + fileName;
                

                await file.CopyToAsync(new FileStream(path, FileMode.Create));


                return dbUrl;
            }
            else
            {
                return null;
            }
        }
    }
}
