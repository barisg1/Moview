using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moview.Models;
using System.Security.Claims;

namespace Moview.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesRepository _moviesRepo;
        private readonly IReviewsRepository _reviewsRepo;
        public readonly IWebHostEnvironment _webHostEnvironment;
        public MoviesController(IMoviesRepository appDbContext, IReviewsRepository reviewsRepository, IWebHostEnvironment webHostEnvironment) {
            _moviesRepo = appDbContext;
            _reviewsRepo = reviewsRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Movies> movies = _moviesRepo.GetAll().ToList();
            return View(movies);
        }
        public IActionResult AllMovies()
        {

            List<Movies> movies = _moviesRepo.GetAll().ToList();

            return View(movies);
        }

        public IActionResult MoviePage(int? id)
        {
            if (id == null || id == 0)
            {
                return View();
            }
            else
            {
                List<Reviews> reviews = _reviewsRepo.GetAllReviewsByMovieId(id);
                Movies? movieDb = _moviesRepo.Get(u => u.MovieId == id);
                movieDb.Reviews = reviews;
                if (movieDb == null)
                {
                    return NotFound();
                }
                return View(movieDb);
            }
        }
        [HttpGet]
        public IActionResult FilterMovies(string selectedLanguage, string selectedGenre, string selectedIMDB, string selectedName)
        {
            List<Movies> movies = _moviesRepo.GetAll().ToList();
            List<string> selectedGenres = selectedGenre.Split(',').Select(s => s.Trim()).ToList();
            var filteredMovies = movies.Where(m =>
               (string.IsNullOrEmpty(selectedLanguage) || m.Language == selectedLanguage) &&
               (string.IsNullOrEmpty(selectedIMDB) || m.IMDB >= Convert.ToDouble(selectedIMDB)) &&
               (string.IsNullOrEmpty(selectedGenres.FirstOrDefault()) || selectedGenres.All(genre => m.Genre.Contains(genre))) &&
               (string.IsNullOrEmpty(selectedName) || m.Title.Contains(selectedName) || m.Director.Contains(selectedName))
           ).ToList();

            return View(filteredMovies);
        }


        public IActionResult AddOrEdit(int? id)
        {
            if (id == null || id == 0)
            {
                return View();
            }
            else
            {
                Movies? movieDb = _moviesRepo.Get(u => u.MovieId == id);
                if (movieDb == null)
                {
                    return NotFound();
                }
                return View(movieDb);
            }
        }
        [HttpPost]
        public IActionResult AddOrEdit(Movies movie, IFormFile? file)
        {
            if(ModelState.IsValid) {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                string moviePath = Path.Combine(wwwRootPath, @"img");
                if (file != null)
                {
                    using (var fileStream = new FileStream(Path.Combine(moviePath, file.FileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    movie.PosterUrl = @"/img/" + file.FileName;
                }
                if(movie.MovieId == 0)
                {
                    _moviesRepo.Add(movie);
                    TempData["success"] = "Movie added successfully";
                }
                else {
                    _moviesRepo.Edit(movie);
                    TempData["success"] = "Movie editted successfully";
                }
                _moviesRepo.Save();
                return RedirectToAction("Index", "Movies");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Movies? movieDb = _moviesRepo.Get(u => u.MovieId == id);
            if (movieDb == null)
            {
                return NotFound();
            }
            return View(movieDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Movies? movie = _moviesRepo.Get(u => u.MovieId == id);
            if (movie == null)
            {
                return NotFound();
            }
            _moviesRepo.Delete(movie);
            _moviesRepo.Save();
            TempData["success"] = "Movie deleted successfully";
            return RedirectToAction("Index", "Movies");
        }
    }
}
