using Forms.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forms.Web.DAL
{
    public interface IFilmDAL
    {
        IList<Film> SearchFilms(string title, string description, int? releaseYear, int? minLength, int? maxLength, string rating);
    }
}
