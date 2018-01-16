using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModel
{
    public class NewMovieFormViewModel
    {
        public IEnumerable<Genre> Genre {get; set; }
        public Movie Movie { get; set; }

        //used to either set new movie or edit movie in MovieForm view. Better than adding
        //view logic due to easier maintainability
        public string Title
        {
            get
            {
                if (Movie != null && Movie.Id != 0)
                {
                    return "Edit Movie";
                }

                return "New Movie";
            }
        }
    }
}