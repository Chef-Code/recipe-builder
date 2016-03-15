using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RecipeBuilder_Version_1.Models
{
    public class MenuItem
    {
        [Key, ForeignKey("Recipe")]
        public int RecipeID { get; set; }
        public string MenuItemName { get; set; }


        public Nullable<int> MenuID { get; set; }
        public virtual Menu Menu { get; set; }
        public Nullable<int> MenuMealID { get; set; }
        public virtual MenuMeal MenuMeal { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}