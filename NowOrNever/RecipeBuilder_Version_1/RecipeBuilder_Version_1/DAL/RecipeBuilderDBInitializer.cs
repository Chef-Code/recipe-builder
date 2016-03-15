using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using RecipeBuilder_Version_1.Models;

namespace RecipeBuilder_Version_1.DAL
{
    //public class RecipeBuilderDBInitializer 
    //public class RecipeBuilderDBInitializer : CreateDatabaseIfNotExists<RecipeBuilder2>
    public class RecipeBuilderDBInitializer : DropCreateDatabaseAlways<RecipeBuilder2Context>
    //public class RecipeBuilderDBInitializer : DropCreateDatabaseIfModelChanges<RecipeBuilder2Context>
    {
        protected override void Seed(RecipeBuilder2Context context)
        {
           
            base.Seed(context);
        }
    }
}