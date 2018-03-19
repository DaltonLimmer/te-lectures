using Forms.Web.DAL;
using Forms.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forms.Web.Controllers
{
    /* Dependency Injection Steps 
        1. Create Interface for DALs
        1A. Have DAL implement the new interface
        2. Add ConnectionString to Web.Config
        3. Add Ninject nuget package (already done in exercises)
        4. Update Global.asax to:
            A. Read ConnectionString from Web.Config
            B. Bind Interface DAL to DAL
        5. Add Constructor and private var to Controller        
    */
    



    /* STEPS
     *1. (FilmController)    Create the index action for film/index
     *2. (Index View)        Create form w/button that submits the data to Film/SearchResult
     *3. (FilmController)    Create the SearchResult action for film/searchresult
     *4. (SearchResult View) Create empty view
     *5. TEST
     *6. (FilmSearchModel)   Create a FilmSearchModel that holds properties user will search by
     *7. (Index View)        Bind the view to a FilmSearchModel
     *8. (Index View)        Add the HTML fields to search by
     *9. TEST
     *10. (FilmController)   Add the FilmSearchModel as a parameter to the film/searchresult action
     *11. DEBUG (show it works!)
     *12. (Global.asax)      Configure IFilmDAL to map to FilmDAL               DI Step 1.
     *13. (FilmController)   Add IFilmDAL as a dependency that is injected      DI Step 5
     *14. (FilmContorller)   Call DAL to search for films
     *15. (FilmController)   Pass films in to the SearchResult view
     *16. (SearchResult View)Update view to display each of the films passed in as the model.
     17. PROCLAIM VICTORY
    */

    public class FilmController : Controller
    {

        /* Step 5 of Dependency Injection */
        private IFilmDAL _dal;
        public FilmController(IFilmDAL dal)
        {
            _dal = dal;
        }

        /* Step 1 */
        public ActionResult Index()
        {
            return View();
        }

        /* Step 3 */                    /* Step 10 */
        public ActionResult SearchResult(FilmSearchViewModel searchModel)
        {
            /* Step 14 */
            IList<Film> films = _dal.SearchFilms(searchModel.Title, searchModel.Description, searchModel.ReleaseYear, searchModel.MinLength, searchModel.MaxLength, searchModel.Rating);

                        /* Step 15 */
            return View(films);
        }


    }
}