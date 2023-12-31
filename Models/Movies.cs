﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
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
        [Range(1.0, 10.0)]
        public double IMDB { get; set; }
        public string Language { get; set; }
        public int Runtime { get; set; }
        [Range(1.0, 10.0)]
        public double Rating { get; set; }
        [ValidateNever]
        public List<Reviews> Reviews { get; set; }
        public string TrailerUrl { get; set; }
    }
}
