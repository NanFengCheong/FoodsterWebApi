using FoodsterApp.BLL;
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
        [Route("api/FoodRecommend/{UserID}")]
        public async Task<object> Get(string UserID)
        {

            string response = await Recommender.InvokeRequestResponseService(UserID);
            var obj = JsonConvert.DeserializeObject<object>(response);
            JObject rss = JObject.Parse(response);
            List<string> arr = new List<string>();
            for(int i = 1; i < 20; i++)
            {
                string tempstring = (string)rss["Results"]["output1"][0]["Item " + i.ToString()];
                if(!string.IsNullOrEmpty(tempstring))
                    arr.Add(tempstring);
            }
            

            return Json(arr);
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
