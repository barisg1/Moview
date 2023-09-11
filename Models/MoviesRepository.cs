using System.Linq.Expressions;

namespace Moview.Models
{
    public class MoviesRepository : Repository<Movies>, IMoviesRepository
    {
        private AppDbContext _context;
        public MoviesRepository(AppDbContext context): base(context)
        {
            _context = context;
        }
        public void Edit(Movies movies)
        {
            _context.Update(movies);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
