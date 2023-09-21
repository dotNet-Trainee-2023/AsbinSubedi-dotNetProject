using System.ComponentModel.DataAnnotations;

namespace Assignment3.Models
{
    public class Movies
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Title of Movie is required")]
        public string Title { get; set; }
        [Required(ErrorMessage ="Enter the release Date.")]
        [DataType(DataType.Date)]
        public DateTime releaseDate { get; set; }

        [Required(ErrorMessage ="Genre is required")]
        public string genre { get; set; }

        [Range(1,10,ErrorMessage ="Rating must be between 1 and 10")]
        public decimal rating { get; set; }

    }
}
