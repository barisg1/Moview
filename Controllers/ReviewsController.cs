using Microsoft.AspNetCore.Mvc;
using Moview.Models;

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
                review.MovieId = id;
                review.ReviewDate = DateTime.Now;
                _reviewsRepo.Add(review);
                _reviewsRepo.Save();
            }
            return View();
        }
        
    }
}
