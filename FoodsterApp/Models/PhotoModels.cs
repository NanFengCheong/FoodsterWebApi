using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FoodsterApp.Models
{
    public class PhotoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PhotoID { get; set; }
        [ForeignKey("Food")]
        public int FoodID { get; set; }
        public FoodModel Food { get; set; }
        public string PhotoLink { get; set; }
    }
}