using GoogleMapsWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GoogleMapsWebApi.Controllers
{
    public class MarkerController : ApiController
    {
        public static IList<Marker> SavedMarkers = new List<Marker>();

        public IList<Marker> GetSavedMarkers()
        {
            return SavedMarkers;
        }


        [HttpPost]
        [Route("api/Marker/add")]
        public HttpResponseMessage PostSaveLocation(Marker marker)
        {

            SavedMarkers.Add(marker);

            return Request.CreateResponse(HttpStatusCode.OK);

        }

        [HttpPost]  //!!!!! THIS REALLY SHOULD BE A DELETE INSTEAD OF A POST !!!!!
        [Route("api/Marker/deleteAll")]
        public HttpResponseMessage DeleteAllMarkers()
        {
            SavedMarkers.Clear();
            return Request.CreateResponse(HttpStatusCode.OK);
        }

    }
}
