using System;
using System.Collections.Generic;


using System.Linq;
using System.Web;

namespace RecipeBuilder_Version_1.Models
{
    public class Ingredient
    {
       /* public Ingredient()
        {
            this.Recipes = new HashSet<Recipe>();
            this.Food = new Food();
            this.UnitOfMeasure = new UnitOfMeasure();
        }*/
        public int IngredientID { get; set; }
        public string IngredientName { get; set; }     
        public decimal UnitQuantity { get; set; }
        public string Preparation { get; set; }
        //public int FoodItemID { get; set; }
        public virtual Food Food { get; set; }
        //public int UnitOfMeasureID { get; set; }
       
        public virtual UnitOfMeasure UnitOfMeasure { get; set; }
        public virtual ICollection<Recipe> Recipes { get; set; }
        

    }
}