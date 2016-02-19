using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipeBuilder_Version_1.Models
{
    public class Menu
    {
        private List<Recipe> recipes = new List<Recipe>();
        //private List<Restaurant> restaurants = new List<Restaurant>();
        public virtual int MenuID { get; set; }

        //public virtual List<Restaurant> Restaurants { get { return restaurants;} set { restaurants = value; } }
      
        public virtual List<Recipe> Recipes
        {
            get { return recipes; }
            set { recipes = value; }
        }                                                                          
    }
}