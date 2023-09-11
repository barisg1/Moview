namespace Moview.Models
{
    public interface IReviewsRepository : IRepository<Reviews>
    {
        void Edit(Reviews reviews);
        void Save();
        List<Reviews> GetAllReviewsByMovieId(int? MovieId);
    }
}
