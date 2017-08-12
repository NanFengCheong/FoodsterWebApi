using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FoodsterApp.Models
{
    public class FoodModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FoodID { get; set; }
        public string Name { get; set; }

        [ForeignKey("PriceRange")]
        public int PriceRangeID { get; set; }
        public PriceRangeModel PriceRange { get; set; }


        [ForeignKey("Restaurant")]
        public int RestaurantID { get; set; }
        public RestaurantModel Restaurant { get; set; }

        public string TagID { get; set; }
        public string MealID { get; set; }
    }
}