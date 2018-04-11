using GetExercises.Web.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApiReview.Controllers
{
    //[EnableCors(origins: "*", headers: "*", methods: "*")]            //Not needed because WebApiConfig sets up CORS for all controllers
    public class ReviewController : ApiController
    {

        private IActorDAL _actors;
        private ICustomerDAL _customers;
        private IFilmDAL _films;

        public ReviewController(IActorDAL adal, ICustomerDAL cdal, IFilmDAL fdal)
        {
            _actors = adal;
            _customers = cdal;
            _films = fdal;
        }

        //public HttpResponseMessage GetFilms()
        //{

        //    var films = _films.GetAllFilms();

        //    return Request.CreateResponse(HttpStatusCode.OK, films);
        //}

        
        public HttpResponseMessage GetFilmsBetween(string genre, int minLength, int maxLength)
        {
            Thread.Sleep(5000);
            var films = _films.GetFilmsBetween(genre, minLength, maxLength);

            return Request.CreateResponse(HttpStatusCode.OK, films);
        }



    }
}
