
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class NewMovieViewModel
    {

        public int? ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Range(minimum: 1, maximum: 20, ErrorMessage = "The Number In Stock Should Be Between 1 To 20")]
        [Display(Name = "Number In Stock")]
        public int? NumberInStock { get; set; }

        
        [Display(Name = "Genre")]
        [Required]
        public int? GenreId { get; set; }

        public List<Genre> Genres { get; set; }

        public string Title 
        { 
            get 
            {
                return ID != 0 ? "Edit Movie" : "New Movie"; 
            } 
        }

        public NewMovieViewModel()
        {
            ID = 0;
        }

        public NewMovieViewModel(Movie movie)
        {
            ID = movie.ID;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            GenreId = movie.GenreId;
            NumberInStock = movie.NumberInStock;
        }
    }
}