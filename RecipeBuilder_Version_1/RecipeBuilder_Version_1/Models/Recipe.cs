using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipeBuilder_Version_1.Models
{
    public class Recipe
    {     
        private List<Ingredient> ingredients = new List<Ingredient>();
        private Ingredient ingredient = new Ingredient();
        public virtual int RecipeID { get; set; }
        public virtual string RecipeName { get; set; }
        public virtual List<Ingredient> Ingredients 
        {
            get { return ingredients; }
            set { ingredients = value; }
        }

        public virtual Ingredient IgredientItem 
        {
            get { return ingredient; } 
            set { ingredient= value;} 
        }       
    }
}