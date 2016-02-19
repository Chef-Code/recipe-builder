using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecipeBuilder_Version_1.Models
{
    public class IngredientViewModel
    {
        private Recipe recipe = new Recipe();


        public int IngredientID { get; set; }
        //[Required]
        public string IngredientName { get; set; }  // this will implement a FoodItem class

        public FoodItem Item { get; set; }
        public UnitOfMeasure Unit { get; set; }
        
        public decimal UnitQuantity { get; set; }
        public string Preparation { get; set; }

        public Recipe RecipeItem { get { return recipe; } set { recipe = value; } }
    }
}