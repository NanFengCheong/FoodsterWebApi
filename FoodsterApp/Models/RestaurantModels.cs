using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodsterApp.Models
{
    public class RestaurantModel
    {
        public int RestaurantID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string GPSLocation { get; set; }
        public string OpeningHours { get; set; }
        public string ContactNo { get; set; }
        public string GooglePlacesID { get; set; }
    }
}