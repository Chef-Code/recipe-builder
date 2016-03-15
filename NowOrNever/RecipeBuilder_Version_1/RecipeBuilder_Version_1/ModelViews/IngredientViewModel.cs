using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipeBuilder_Version_1.ModelViews
{
    public class IngredientViewModel
    {
        public int IngredVMID { get; set; }
        public string FoodItem { get; set; }
        public string UnitOfMeasure { get; set; }

        public decimal UnitQuantity { get; set; }
        public string Preparation { get; set; }
        public string Recipe { get; set; }
    }
}