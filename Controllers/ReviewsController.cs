using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Moview.Models;
using System.Security.Claims;

namespace Moview.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly IReviewsRepository _reviewsRepo;
        private int movieid;
        public ReviewsController(IReviewsRepository reviewsRepository)
        {
            _reviewsRepo = reviewsRepository;
            this.movieid = 0;
        }
        public IActionResult Index(int id)
        {
            ViewBag.MovieId = id;
            return View();
        }
        [HttpPost]
        public IActionResult Index(Reviews review, int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                review.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                review.MovieId = id;
                review.ReviewDate = DateTime.Now;
                _reviewsRepo.Add(review);
                _reviewsRepo.Save();
            }
            return RedirectToAction("MoviePage", "Movies", new {id = id });
        }
        
        public IActionResult Delete(int id)
        {
            var entity = _reviewsRepo.Get(x => x.ReviewId == id);
            int movId = entity.MovieId;
            _reviewsRepo.Delete(entity);
            _reviewsRepo.Save();
            return RedirectToAction("MoviePage", "Movies", new {id = movId});
        }
    }
}
