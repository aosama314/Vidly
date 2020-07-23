using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public Movie()
        {
            DataAdded = DateTime.Now;
        }

        public int ID { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Range(minimum: 1, maximum: 20, ErrorMessage = "The Number In Stock Should Be Between 1 To 20")]
        [Display(Name = "Number In Stock")]
        public int NumberInStock { get; set; }

        public int NumberAvailable { get; set; }

        [Required]
        //public static DateTime Now { get; set; }
        public DateTime DataAdded { get; set; }

        public Genre Genre { get; set; }

        [Display(Name = "Genre Type")]
        [Required]
        public int GenreId { get; set; }
    }
}