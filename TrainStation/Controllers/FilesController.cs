using Microsoft.AspNetCore.Mvc;
using TrainStation.Models;
using TrainStation.Services.Interfaces;

namespace TrainStation.Controllers
{
    public class FilesController : Controller
    {
        private readonly IFileService _fileService;

        public FilesController(IFileService fileService)
        {
            _fileService = fileService;
        }

        public IActionResult Index()
        {
            var files = _fileService.ReadFiles();

            return View(new FileNamesListModel() 
            { 
                FileNames = files 
            });
        }

        [HttpGet]
        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            await _fileService.UploadFileAsync(file);
            return View(file);
        }

        public IActionResult ViewFile([FromQuery] string fileName)
        {
            return View(new FileViewModel
            {
                Content = _fileService.ReadFile(fileName)
            });
        }
    }
}
