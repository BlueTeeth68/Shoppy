using Microsoft.AspNetCore.Http;

namespace Shoppy.Application.Services.Interfaces;

public interface IFileService
{
    Task<string> UploadImageAsync(IFormFile file, string folderPath, string fileName);
}