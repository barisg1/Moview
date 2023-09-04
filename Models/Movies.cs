using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Moview.Models
{
    public class Movies
    {
        [Key]
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ReleaseDate { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        [ValidateNever]
        public string PosterUrl { get; set; }
    }
}
