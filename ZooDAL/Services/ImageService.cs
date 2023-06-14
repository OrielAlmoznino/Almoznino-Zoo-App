using Azure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooDAL.Entities;
using ZooDAL.Services.Interfaces;

namespace ZooDAL.Services
{
    public class ImageService : IImageService
    {
        private readonly IHostingEnvironment _env;
        public ImageService(IHostingEnvironment env)
        {
            _env = env;
        }
        public string GetFullImagePath(string fileName)
        {
            return Path.Combine(_env.WebRootPath, "Images", fileName);
        }
        public async Task<string> CreateImageFromUrl(string imageUrl, Guid uid)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(imageUrl);
                response.EnsureSuccessStatusCode();

                byte[] imageData = await response.Content.ReadAsByteArrayAsync();

                string contentType = response.Content.Headers.ContentType?.MediaType;
                string fileExtension = GetFileExtensionFromContentType(contentType);

                string fileName = $"{uid}{fileExtension}";
                string filePath = Path.Combine(_env.WebRootPath, "Images", fileName);

                using (Image image = Image.Load(imageData))
                {
                    image.Mutate(x => x.Resize(400, 400)); // Resize the image 

                    await Task.Run(() => image.Save(filePath)); // Save the resized image
                }

                return fileName;
            }
        }
        public async Task<string> CreateImageFromLocal(IFormFile file, Guid uid)
        {
            string fileExtension = Path.GetExtension(file.FileName);
            string fileName = $"{uid}{fileExtension}";

            string filePath = Path.Combine(_env.WebRootPath, "Images", fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            using (Image image = Image.Load(filePath))
            {
                image.Mutate(x => x.Resize(400, 400));

                image.Save(filePath);
            }

            return fileName;
        }
        private string GetFileExtensionFromContentType(string contentType)
        {
            switch (contentType)
            {
                case "image/jpeg":
                    return ".jpg";
                case "image/png":
                    return ".png";
                case "image/gif":
                    return ".gif";
                case "image/bmp":
                    return ".bmp";
                case "image/tiff":
                    return ".tiff";
                case "image/webp":
                    return ".webp";
                default:
                    return string.Empty;
            }
        }
        public async Task<bool> DeleteImage(string fileName)
        {
            string imagePath = GetFullImagePath(fileName);
            bool isDeleted = false;

            try
            {
                File.Delete(imagePath);
                isDeleted = true;
            }
            catch (Exception ex)
            {
                isDeleted = false;
            }

            return isDeleted;
        }

    }
}
