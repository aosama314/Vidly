using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Range(minimum: 1, maximum: 20, ErrorMessage = "The Number In Stock Should Be Between 1 To 20")]
        public int NumberInStock { get; set; }

        [Required]
        //public static DateTime Now { get; set; }
        public DateTime DataAdded { get; set; }

        public GenreDto Genre { get; set; }

        [Required]
        public int GenreId { get; set; }
    }
}