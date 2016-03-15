using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using RecipeBuilder_Version_1.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Text;
namespace RecipeBuilder_Version_1.DAL
{
    public class RecipeBuilder2Context : IdentityDbContext<Member>
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public RecipeBuilder2Context() : base("name=RecipeBuilder2Context")
        {
            Database.SetInitializer<RecipeBuilder2Context>(new MigrateDatabaseToLatestVersion<RecipeBuilder2Context, RecipeBuilder_Version_1.Migrations.Configuration>("RecipeBuilder2Context"));
            //Database.SetInitializer(new System.Data.Entity.MigrateDatabaseToLatestVersion<RecipeBuilder2Context, RecipeBuilder_Version_1.Migrations.Configuration>("RecipeBuilder2Context"));
                //RecipeBuilder_Version_1.DAL.CreateDatabaseIfNotExists<RecipeBuilder2>)
        }
        public System.Data.Entity.DbSet<RecipeBuilder_Version_1.Models.Menu> Menus { get; set; }
        public System.Data.Entity.DbSet<RecipeBuilder_Version_1.Models.MenuMeal> MenuMeals { get; set; }
        public System.Data.Entity.DbSet<RecipeBuilder_Version_1.Models.MenuItem> MenuItems { get; set; }       
        public System.Data.Entity.DbSet<RecipeBuilder_Version_1.Models.Recipe> Recipes { get; set; }
        public System.Data.Entity.DbSet<RecipeBuilder_Version_1.Models.Ingredient> Ingredients { get; set; }

        public System.Data.Entity.DbSet<RecipeBuilder_Version_1.Models.FoodItem> FoodItems { get; set; }       
        public System.Data.Entity.DbSet<RecipeBuilder_Version_1.Models.UnitOfMeasure> UnitOfMeasures { get; set; }

        public System.Data.Entity.DbSet<RecipeBuilder_Version_1.Models.Package> Packages { get; set; }
        public System.Data.Entity.DbSet<RecipeBuilder_Version_1.Models.AsPurchasedItem> AsPurchasedItems { get; set; }
        public System.Data.Entity.DbSet<RecipeBuilder_Version_1.Models.Food> Foods { get; set; }

        //Added DBSets

        public System.Data.Entity.DbSet<RecipeBuilder_Version_1.Models.Topic> Topics { get; set; }
        public System.Data.Entity.DbSet<RecipeBuilder_Version_1.Models.Forum> Fora { get; set; }
        public System.Data.Entity.DbSet<RecipeBuilder_Version_1.Models.Comment> Comments { get; set; }
        public System.Data.Entity.DbSet<RecipeBuilder_Version_1.Models.Message> Messages { get; set; }
        public System.Data.Entity.DbSet<RecipeBuilder_Version_1.Models.Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            //modelBuilder.Configurations.Add(new IngredientEntityConfiguration());
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            /************************************************/
          //Creates a Many-to-Many Bridge Table in the Database           
            modelBuilder.Entity<Recipe>()
                .HasMany(r => r.Ingredients)
                .WithMany(i => i.Recipes)
                .Map(m =>
                {
                    m.MapLeftKey("RecipeID");
                    m.MapRightKey("IngredientID");
                    m.ToTable("RecipeIngredient");
                });

            /************************************************/
            modelBuilder.Entity<Menu>()
                .HasMany<MenuItem>(m => m.MenuItems);

            modelBuilder.Entity<Menu>()
                .HasMany<MenuMeal>(m => m.MenuMeals);

            modelBuilder.Entity<MenuMeal>()
                .HasOptional<Menu>(m => m.Menu)
                .WithMany(m => m.MenuMeals);

            modelBuilder.Entity<MenuItem>()
                .HasOptional<Menu>(m => m.Menu)
                .WithMany(m => m.MenuItems);
                   
          //one-or-zero-to-many
            modelBuilder.Entity<MenuItem>()
                    .HasOptional<MenuMeal>(m => m.MenuMeal)  
                    .WithMany(m => m.MenuItems);

            /************************************************/
         

            base.OnModelCreating(modelBuilder);
        }
    }
}