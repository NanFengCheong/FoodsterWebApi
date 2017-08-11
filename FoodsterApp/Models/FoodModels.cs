using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodsterApp.Models
{
    public class FoodModel
    {
        public int FoodID { get; set; }
        public string Name { get; set; }
        public int PriceRange { get; set; }
        public int RestaurantID { get; set; }
        public string TagID { get; set; }
        public string MealID { get; set; }
    }
}