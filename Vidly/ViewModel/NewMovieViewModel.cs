using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModel
{
    public class NewMovieFormViewModel
    {
        public NewMovieFormViewModel()
        {
            //needs to be 0 to ensure hidden field is populated in view (for validation)
            Id = 0;
        }

        public NewMovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
        }


        public IEnumerable<Genre> Genre { get; set; }
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public byte? GenreId { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Number in Stock")]
        [Required]
        [Range(1, 20)]
        public byte? NumberInStock { get; set; }

        //used to either set new movie or edit movie in MovieForm view. Better than adding
        //view logic due to easier maintainability
        public string Title => (Id != 0) ? "Edit Movie" : "New Movie";
    }
}