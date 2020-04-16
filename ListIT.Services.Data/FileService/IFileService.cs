using ListIT.Data.Common.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ListIT.Services.Data.FileService
{
    public interface IFileService
    {
        public Task<string> UploadFile(IFormFile file,FileType fileType);
    }
}
