using Forms.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forms.Web.DAL
{
    /* Step 1 */
    public interface IFilmDAL
    {
        IList<Film> SearchFilms(string title, string description, int? releaseYear, int? minLength, int? maxLength, string rating);
    }
}
