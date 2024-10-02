using DataMatrixCase.Infrastructure.Interfaces.Services;
using DataMatrixCase.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.IO;
using System.Web;

namespace DataMatrixCase.MVC.Controllers
{
    public class DataMatrixController : Controller
    {
        private readonly ILogger<DataMatrixController> _logger;
        private readonly IDataMatrixService _dataMatrixService;
        public DataMatrixController(ILogger<DataMatrixController> logger, IDataMatrixService dataMatrixService)
        {
            _logger = logger;
            _dataMatrixService = dataMatrixService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UploadImage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UploadImage(IFormFile imageFile)
        {

            if (imageFile != null && imageFile.Length > 0)
            {
                try
                {
                    // Check if the file is an image
                    var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                    var fileExtension = Path.GetExtension(imageFile.FileName).ToLower();

                    if (!allowedExtensions.Contains(fileExtension))
                    {
                        ViewBag.Error = "Invalid file type. Please upload an image file (JPG, JPEG, PNG, GIF).";
                        return View();
                    }

                    // Convert the uploaded IFormFile to a Bitmap
                    using (var stream = new MemoryStream())
                    {
                        imageFile.CopyTo(stream);
                        stream.Seek(0, SeekOrigin.Begin);

                        List<string> decodedCodes = _dataMatrixService.Decode(stream, imageFile.FileName).Result;

                        // Pass decoded codes to the view using ViewBag
                        ViewBag.DecodedCodes = decodedCodes;

                        return View();
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Error = "Error decoding image: " + ex.Message;
                    return View();
                }
            }
            else
            {
                ViewBag.Error = "Please upload a valid image file.";
                return View();
            }
        }

        [HttpPost]
        public IActionResult ClearAll()
        {
            _dataMatrixService.ClearAll().Wait();
            ViewBag.DecodedCodes = null;

            return RedirectToAction("Index", "Home");
        }
    }
}