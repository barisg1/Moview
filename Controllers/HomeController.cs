using Microsoft.AspNetCore.Mvc;
using Moview.Models;
using System.Diagnostics;

namespace Moview.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMoviesRepository _moviesRepo;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IMoviesRepository moviesRepo)
        {
            _logger = logger;
            _moviesRepo = moviesRepo;
        }

        public IActionResult Index()
        {
            List<Movies> movies = _moviesRepo.GetAll().ToList();
            return View(movies);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Profile()
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