using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace RecipeBuilder_Version_1.Models
{
    public class RecipeBuilderDBInitializer : DropCreateDatabaseAlways<RecipeBuilder_Version_1Context>
    //public class RecipeBuilderDBInitializer : DropCreateDatabaseIfModelChanges<RecipeBuilder_Version_1Context>
    {
        protected override void Seed(RecipeBuilder_Version_1Context context)
        {
            FoodItem fooditem1 = new FoodItem { FoodItemID = 1, EPYieldPercentage = 0.5m, FoodName = "Tomato", PotHazFood = false };
            Ingredient ingredient1 = new Ingredient { IngredientID = 1, IngredientName = "egg", Item = { FoodItemID = 1}, UnitQuantity = 1.0m, Preparation = "Boil" };
            Ingredient ingredient2 = new Ingredient { IngredientID = 2, IngredientName = " clarified butter", UnitQuantity = 1.0m, Preparation = "clarify"  };
            Recipe recipe1 = new Recipe { RecipeName = "Hollandaise", Ingredients = {ingredient1, ingredient2}};
            
            //recipe1.Ingredients.Add(egg);
            //recipe1.Ingredients.Add(butter);
            context.Recipes.Add(recipe1);

            base.Seed(context);
        }
    }
}