using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipeBuilder_Version_1.Models
{
    public class Ingredient
    {
        private FoodItem item;
        public virtual int IngredientID { get; set; }
        public virtual int RecipeID { get; set; }
        public virtual string IngredientName { get; set; }
        public virtual FoodItem Item { get { return item; } set { item = value;} }
        public virtual UnitOfMeasure Unit { get; set; }
        public virtual decimal UnitQuantity { get; set; }
        public virtual string Preparation { get; set; }
    }
}