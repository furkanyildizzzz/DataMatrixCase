using DataMatrixCase.Application.Dto;
using DataMatrixCase.Infrastructure.Interfaces.Services;
using DataMatrixCase.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DataMatrixCase.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDataMatrixService _dataMatrixService;

        public HomeController(ILogger<HomeController> logger, IDataMatrixService dataMatrixService)
        {
            _logger = logger;
            _dataMatrixService = dataMatrixService;
        }

        public IActionResult Index()
        {
            List<DataMatrixInfoDto> decodedItems = _dataMatrixService.DecodedItems().Result;

            ViewBag.DecodedItems = decodedItems;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}