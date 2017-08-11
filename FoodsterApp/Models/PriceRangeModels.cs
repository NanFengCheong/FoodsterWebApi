using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodsterApp.Models
{
    public class PriceRangeModel
    {
        public int PriceRangeID { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
    }
}