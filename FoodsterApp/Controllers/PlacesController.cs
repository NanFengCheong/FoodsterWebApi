using GoogleApi;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Places.Search.Common.Enums;
using GoogleApi.Entities.Places.Search.NearBy.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Configuration;
using GoogleApi.Entities.Places.Details.Request;

namespace FoodsterApp.Controllers
{
    public class PlacesController : ApiController
    {
        // GET: api/Places
        public object Get(double latitude = 2.92105, double longitute= 101.66700, int radius = 1000)
        {
            PlacesNearBySearchRequest request = new PlacesNearBySearchRequest
            {
                Key = ConfigurationManager.AppSettings["GoogleApiKey"],
                Location = new Location(latitude, longitute),
                Radius = radius,
                Type = SearchPlaceType.Restaurant
            };
            var result = GooglePlaces.NearBySearch.Query(request);
            return Json(result);
        }

        // GET: api/Places/5
        public object Get(string id)
        {
            PlacesDetailsRequest request = new PlacesDetailsRequest
            {
                Key = ConfigurationManager.AppSettings["GoogleApiKey"],
                PlaceId = id
            };
            return Json(GooglePlaces.Details.Query(request));
        }

        // POST: api/Places
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Places/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Places/5
        public void Delete(int id)
        {
        }
    }
}
