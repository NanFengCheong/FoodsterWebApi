using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Places.Search.NearBy.Request;
using GoogleApi.Entities.Places.Search.NearBy.Request.Enums;
using Microsoft.AspNetCore.Mvc;

namespace FoodsterSln.Controllers
{
    [Produces("application/json")]
    [Route("api/Places")]
    public class PlacesController : Controller
    {
        // GET: api/Places
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var request = new PlacesNearBySearchRequest
            {
                Key = null,
                Location = new Location(0, 0),
                Radius = 5000,
                Keyword = "test"
            };
            return new string[] { "value1", "value2" };
        }

        // GET: api/Places/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Places
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Places/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
