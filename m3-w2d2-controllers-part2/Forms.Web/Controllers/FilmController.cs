using Forms.Web.DAL;
using Forms.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forms.Web.Controllers
{
    /* STEPS
     1. (FilmController)    Create the index action for film/index
     2. (Index View)        Create form w/button that submits the data to Film/SearchResult
     3. (FilmController)    Create the SearchResult action for film/searchresult
     4. (SearchResult View) Create empty view
     5. TEST
     6. (FilmSearchModel)   Create a FilmSearchModel that holds properties user will search by
     7. (Index View)        Bind the view to a FilmSearchModel
     8. (Index View)        Add the HTML fields to search by
     9. TEST
     10. (FilmController)   Add the FilmSearchModel as a parameter to the film/searchresult action
     11. DEBUG (show it works!)
     12. (Global.asax)      Configure IFilmDAL to map to FilmDAL
     13. (FilmController)   Add IFilmDAL as a dependency that is injected
     14. (FilmContorller)   Call DAL to search for films
     15. (FilmController)   Pass films in to the SearchResult view
     16. (SearchResult View)Update view to display each of the films passed in as the model.
     17. PROCLAIM VICTORY
    */

    public class FilmController : Controller
    {
        IFilmDAL dal;
        public FilmController(IFilmDAL dal)
        {
            this.dal = dal;
        }



        // GET: Film
        public ActionResult Index()
        {
            return View("Index");
        }


        public ActionResult SearchResult(FilmSearchModel filmSearch) //7. Add Model as a param
        {
            var films = dal.SearchFilms(filmSearch.Title, filmSearch.Description, filmSearch.ReleaseYear, filmSearch.MinLength, filmSearch.MaxLength, filmSearch.Rating);

            return View("SearchResult", films); //8. pass in the films as the model
        }
    }
}