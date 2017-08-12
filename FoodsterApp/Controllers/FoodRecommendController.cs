using FoodsterApp.BLL;
using FoodsterApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FoodsterApp.Controllers
{
    public class FoodRecommendController : ApiController
    {
        // GET: api/FoodRecommend
        public async Task<object> Get(string UserID, string TagId="")
        {
            string response = await Recommender.InvokeRequestResponseService(UserID);
            var obj = JsonConvert.DeserializeObject<object>(response);
            JObject rss = JObject.Parse(response);
            List<int> arr = new List<int>();

            for(int i = 1; i < 20; i++)
            {
                string tempstring = (string)rss["Results"]["output1"][0]["Item " + i.ToString()];
                if(!string.IsNullOrEmpty(tempstring))
                    arr.Add( int.Parse(tempstring));
            }

            ApplicationDbContext ApplicationDbContext = new ApplicationDbContext();
            var arr3 = ApplicationDbContext.FoodModels.Include("Restaurant")
                .Where(c => arr.Contains(c.FoodID) && c.TagID.Contains(TagId))
                .Select(x => new { x.Restaurant.Name,x.Restaurant.GPSLocation,  x}).ToList();
            //var arr2 = ApplicationDbContext.FoodModels.Where(c => arr3.Contains(c.RestaurantID)).ToList();
            return Json(arr2);
        }

        // POST: api/FoodRecommend
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/FoodRecommend/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/FoodRecommend/5
        public void Delete(int id)
        {
        }
    }
}
