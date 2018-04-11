using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GetExercises.Web.Models
{
    public class FilmSearch
    {
        public int? MinimumLength { get; set; }
        public int? MaximumLength { get; set; }
        public string Genre { get; set; }
        public List<SelectListItem> Genres { get; set; } = new List<SelectListItem>()
        {
            new SelectListItem{ Text = "Comedy", Value="Comedy" },
            new SelectListItem{ Text = "Action", Value = "Action" },
            new SelectListItem{ Text = "Horror", Value = "Horror" },
            new SelectListItem{ Text = "Family", Value = "Family" },
            new SelectListItem{ Text = "Drama", Value = "Drama" },
        };

        public IList<Film> Results { get; set; } = new List<Film>();
    }
}