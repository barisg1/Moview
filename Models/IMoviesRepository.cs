namespace Moview.Models
{
    public interface IMoviesRepository : IRepository<Movies>
    {
        void Edit(Movies movies);
        void Save();
    }
}
