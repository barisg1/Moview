using System.Linq.Expressions;

namespace Moview.Models
{
    public class ReviewsRepository : Repository<Reviews>, IReviewsRepository
    {
        private AppDbContext _context;
        public ReviewsRepository(AppDbContext context): base(context)
        {
            _context = context;
        }
        public void Edit(Reviews reviews)
        {
            _context.Update(reviews);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
        public List<Reviews> GetAllReviewsByMovieId(int? movieId)
        {
            return _context.Reviews
                .Where(r => r.MovieId == movieId)
                .ToList();
        }
    }
}
