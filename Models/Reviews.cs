using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Moview.Models
{
    public class Reviews
    {
        [Key]
        public int ReviewId { get; set; }

        [Required]
        public int MovieId { get; set; }
        [ForeignKey("MovieId")]
        public Movies Movie { get; set; }

        [Required]
        [Range(1, 10)]
        public int Rating { get; set;}

        [Required]
        [MaxLength(500)]
        public string Comment { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ReviewDate { get; set; }
    }
}
