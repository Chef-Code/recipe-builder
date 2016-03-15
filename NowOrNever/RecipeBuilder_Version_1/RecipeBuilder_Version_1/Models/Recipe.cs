using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipeBuilder_Version_1.Models
{
    public class Recipe
    {
       /* public Recipe()
        {
            this.Ingredients = new HashSet<Ingredient>();
            this.MenuItem = new MenuItem();
        }*/
        public int RecipeID { get; set; }
        public string RecipeName { get; set; }  //MenuItem
        public decimal RecipeCost { get; set; }
        public decimal MenuItemQuantity { get; set; }


        public virtual MenuItem MenuItem { get; set; }
        public virtual ICollection<Ingredient> Ingredients { get; set; }      
        }
        
    
}