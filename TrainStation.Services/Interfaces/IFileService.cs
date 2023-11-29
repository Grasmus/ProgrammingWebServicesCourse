using Microsoft.AspNetCore.Http;

namespace TrainStation.Services.Interfaces
{
    public interface IFileService
    {
        List<string>? ReadFiles();
        Task UploadFileAsync(IFormFile file);
        string ReadFile(string fileName);
    }
}
