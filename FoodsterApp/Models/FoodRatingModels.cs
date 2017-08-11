using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FoodsterApp.Models
{
    public class FoodRatingModel
    {
       
        public int FoodRatingID { get; set; }
        [ForeignKey("Food")]
        public int FoodID { get; set; }
        public FoodModel Food { get; set; }
        public int UserID { get; set; }
        public int Rating { get; set; }
    }
}