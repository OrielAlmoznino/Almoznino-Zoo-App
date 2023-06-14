using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooDAL.Services.Interfaces
{
    public interface IImageService
    {
        string GetFullImagePath(string fileName);
        Task<string> CreateImageFromUrl(string url, Guid uid);
        Task<string> CreateImageFromLocal(IFormFile file,Guid uid);
        Task<bool> DeleteImage(string url);
    }
}
