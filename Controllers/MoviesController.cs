using Microsoft.AspNetCore.Mvc;
using Moview.Models;

namespace Moview.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesRepository _moviesRepo;
        public readonly IWebHostEnvironment _webHostEnvironment;
        public MoviesController(IMoviesRepository appDbContext, IWebHostEnvironment webHostEnvironment) {
            _moviesRepo = appDbContext;
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
        /*public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            Movies? movieDb = _moviesRepo.Get(u => u.MovieId == id);
            if(movieDb == null)
            {
                return NotFound();
            }
            return View(movieDb);
        }
        [HttpPost]
        public IActionResult Edit(Movies movie)
        {
            if (ModelState.IsValid)
            {
                _moviesRepo.Edit(movie);
                _moviesRepo.Save();
                TempData["success"] = "Movie edited successfully";
                return RedirectToAction("Index", "Movies");
            }
            return View();
        }
        */
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
