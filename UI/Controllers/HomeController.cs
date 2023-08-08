using Application.DTO;
using Application.Services;
using Domain.Entities.Games;
using Infrastructure.UnitOfWork.Interface;
using Infrastructure.UnitOfWork.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UI.Models;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeService _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IHomeService unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var carouselGames = await _unitOfWork.GetCarouselGames();
            var allGames = await _unitOfWork.GetAllGames();

            var viewModel = new
            {
                CarouselGames = carouselGames,
                AllGames = allGames
            };

            return View(viewModel);
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