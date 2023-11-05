using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace AspNetMVC.Controllers
{
    public class FileController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public FileController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DownloadFile(string Name, string Surname, string fileName)
        {
            if (!fileName.EndsWith(".txt"))
            {
                fileName += ".txt";
            }

            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "downloads", fileName);

            var fileContent = $"Name: {Name}{Environment.NewLine} Surname: {Surname}";

            await System.IO.File.WriteAllTextAsync(filePath, fileContent, Encoding.UTF8);

            return PhysicalFile(filePath, "text/plain", fileName);
        }

    }
}
