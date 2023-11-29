using Microsoft.AspNetCore.Http;
using System.Text;
using TrainStation.Services.Interfaces;

namespace TrainStation.Services
{
    public class FileService : IFileService
    {
        private readonly string _path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files");

        public List<string>? ReadFiles()
        {
            List<string> fileNames = new List<string>();
            var files = Directory.GetFiles(_path);

            if (files.Length == 0)
            {
                return null;
            }

            foreach (var file in files)
            {
                fileNames.Add(Path.GetFileName(file));
            }

            return fileNames;
        }

        public async Task UploadFileAsync(IFormFile file)
        {
            if (file == null)
            {
                return;
            }

            var fileName = Path.Combine(_path, file.FileName);

            using var fileStream = new FileStream(fileName, FileMode.Create);
            await file.CopyToAsync(fileStream);
        }

        public string ReadFile(string fileName)
        {
            var fileFullNamePath = Path.Combine(_path, fileName);

                  using var fileStream = new FileStream(fileFullNamePath, FileMode.Open);
      byte[] readBytes = new byte[1024];

            if (fileStream == null)
            {
                return string.Empty;
            }

            var bytesSizeRead = fileStream.Read(readBytes, 0, 1024);

            return Encoding.Default.GetString(readBytes, 0, bytesSizeRead);
        }
    }
}
