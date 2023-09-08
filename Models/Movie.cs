using System.ComponentModel.DataAnnotations;

namespace Moview.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public int Runtime { get; set; }
        public decimal Rating { get; set; }
        public string Language { get; set; }
    }
}
