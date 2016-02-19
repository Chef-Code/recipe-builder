using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RecipeBuilder_Version_1.Models
{
    public class RecipeBuilder_Version_1Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public RecipeBuilder_Version_1Context() : base("name=RecipeBuilder_Version_1Context")
        {
        }

        public System.Data.Entity.DbSet<RecipeBuilder_Version_1.Models.Recipe> Recipes { get; set; }

        public System.Data.Entity.DbSet<RecipeBuilder_Version_1.Models.Ingredient> Ingredients { get; set; }

        public System.Data.Entity.DbSet<RecipeBuilder_Version_1.Models.Menu> Menus { get; set; }
    
    }
}
