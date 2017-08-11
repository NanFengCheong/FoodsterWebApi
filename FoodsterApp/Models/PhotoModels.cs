using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodsterApp.Models
{
    public class PhotoModel
    {
        public int PhotoID { get; set; }
        public int FoodID { get; set; }
        public string PhotoLink { get; set; }
    }
}