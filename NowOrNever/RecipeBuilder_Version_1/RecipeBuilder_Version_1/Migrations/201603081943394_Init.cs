namespace RecipeBuilder_Version_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AsPurchasedItem",
                c => new
                    {
                        AsPurchasedItemID = c.Int(nullable: false, identity: true),
                        AsPurchasedName = c.String(),
                        FoodItemQuantity = c.Int(nullable: false),
                        AsPurchasedUnitQuantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FoodItem_FoodItemID = c.Int(),
                        UnitOfMeasure_UnitOfMeasureID = c.Int(),
                    })
                .PrimaryKey(t => t.AsPurchasedItemID)
                .ForeignKey("dbo.FoodItem", t => t.FoodItem_FoodItemID)
                .ForeignKey("dbo.UnitOfMeasure", t => t.UnitOfMeasure_UnitOfMeasureID)
                .Index(t => t.FoodItem_FoodItemID)
                .Index(t => t.UnitOfMeasure_UnitOfMeasureID);
            
            CreateTable(
                "dbo.FoodItem",
                c => new
                    {
                        FoodItemID = c.Int(nullable: false, identity: true),
                        FoodName = c.String(),
                        Specification = c.String(),
                        IndividualAsPurchasedWeight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        YieldPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PotentiallyHazardous = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.FoodItemID);
            
            CreateTable(
                "dbo.UnitOfMeasure",
                c => new
                    {
                        UnitOfMeasureID = c.Int(nullable: false, identity: true),
                        Unit = c.String(),
                        UnitQuantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.UnitOfMeasureID);
            
            CreateTable(
                "dbo.Food",
                c => new
                    {
                        FoodID = c.Int(nullable: false, identity: true),
                        FoodName = c.String(),
                        Specification = c.String(),
                        IndividualAsPurchasedWeight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        YieldPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PotentiallyHazardous = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.FoodID);
            
            CreateTable(
                "dbo.Ingredient",
                c => new
                    {
                        IngredientID = c.Int(nullable: false, identity: true),
                        IngredientName = c.String(),
                        UnitQuantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Preparation = c.String(),
                        Food_FoodID = c.Int(),
                        UnitOfMeasure_UnitOfMeasureID = c.Int(),
                    })
                .PrimaryKey(t => t.IngredientID)
                .ForeignKey("dbo.Food", t => t.Food_FoodID)
                .ForeignKey("dbo.UnitOfMeasure", t => t.UnitOfMeasure_UnitOfMeasureID)
                .Index(t => t.Food_FoodID)
                .Index(t => t.UnitOfMeasure_UnitOfMeasureID);
            
            CreateTable(
                "dbo.Recipe",
                c => new
                    {
                        RecipeID = c.Int(nullable: false, identity: true),
                        RecipeName = c.String(),
                        RecipeCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MenuItemQuantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.RecipeID);
            
            CreateTable(
                "dbo.MenuItem",
                c => new
                    {
                        RecipeID = c.Int(nullable: false),
                        MenuItemName = c.String(),
                        MenuID = c.Int(),
                        MenuMealID = c.Int(),
                    })
                .PrimaryKey(t => t.RecipeID)
                .ForeignKey("dbo.Menu", t => t.MenuID)
                .ForeignKey("dbo.MenuMeal", t => t.MenuMealID)
                .ForeignKey("dbo.Recipe", t => t.RecipeID)
                .Index(t => t.RecipeID)
                .Index(t => t.MenuID)
                .Index(t => t.MenuMealID);
            
            CreateTable(
                "dbo.Menu",
                c => new
                    {
                        MenuID = c.Int(nullable: false, identity: true),
                        MenuName = c.String(),
                        MenuDesigner = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MenuID);
            
            CreateTable(
                "dbo.MenuMeal",
                c => new
                    {
                        MenuMealID = c.Int(nullable: false, identity: true),
                        MenuMealName = c.String(),
                        MenuID = c.Int(),
                    })
                .PrimaryKey(t => t.MenuMealID)
                .ForeignKey("dbo.Menu", t => t.MenuID)
                .Index(t => t.MenuID);
            
            CreateTable(
                "dbo.Package",
                c => new
                    {
                        PackageID = c.Int(nullable: false, identity: true),
                        PackageCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        VendorCode = c.String(),
                        QRCode = c.String(),
                        AsPurchasedItemID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PackageID)
                .ForeignKey("dbo.AsPurchasedItem", t => t.AsPurchasedItemID, cascadeDelete: true)
                .Index(t => t.AsPurchasedItemID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        NickName = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.RecipeIngredient",
                c => new
                    {
                        RecipeID = c.Int(nullable: false),
                        IngredientID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RecipeID, t.IngredientID })
                .ForeignKey("dbo.Recipe", t => t.RecipeID, cascadeDelete: true)
                .ForeignKey("dbo.Ingredient", t => t.IngredientID, cascadeDelete: true)
                .Index(t => t.RecipeID)
                .Index(t => t.IngredientID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Package", "AsPurchasedItemID", "dbo.AsPurchasedItem");
            DropForeignKey("dbo.Ingredient", "UnitOfMeasure_UnitOfMeasureID", "dbo.UnitOfMeasure");
            DropForeignKey("dbo.MenuItem", "RecipeID", "dbo.Recipe");
            DropForeignKey("dbo.MenuItem", "MenuMealID", "dbo.MenuMeal");
            DropForeignKey("dbo.MenuItem", "MenuID", "dbo.Menu");
            DropForeignKey("dbo.MenuMeal", "MenuID", "dbo.Menu");
            DropForeignKey("dbo.RecipeIngredient", "IngredientID", "dbo.Ingredient");
            DropForeignKey("dbo.RecipeIngredient", "RecipeID", "dbo.Recipe");
            DropForeignKey("dbo.Ingredient", "Food_FoodID", "dbo.Food");
            DropForeignKey("dbo.AsPurchasedItem", "UnitOfMeasure_UnitOfMeasureID", "dbo.UnitOfMeasure");
            DropForeignKey("dbo.AsPurchasedItem", "FoodItem_FoodItemID", "dbo.FoodItem");
            DropIndex("dbo.RecipeIngredient", new[] { "IngredientID" });
            DropIndex("dbo.RecipeIngredient", new[] { "RecipeID" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Package", new[] { "AsPurchasedItemID" });
            DropIndex("dbo.MenuMeal", new[] { "MenuID" });
            DropIndex("dbo.MenuItem", new[] { "MenuMealID" });
            DropIndex("dbo.MenuItem", new[] { "MenuID" });
            DropIndex("dbo.MenuItem", new[] { "RecipeID" });
            DropIndex("dbo.Ingredient", new[] { "UnitOfMeasure_UnitOfMeasureID" });
            DropIndex("dbo.Ingredient", new[] { "Food_FoodID" });
            DropIndex("dbo.AsPurchasedItem", new[] { "UnitOfMeasure_UnitOfMeasureID" });
            DropIndex("dbo.AsPurchasedItem", new[] { "FoodItem_FoodItemID" });
            DropTable("dbo.RecipeIngredient");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Package");
            DropTable("dbo.MenuMeal");
            DropTable("dbo.Menu");
            DropTable("dbo.MenuItem");
            DropTable("dbo.Recipe");
            DropTable("dbo.Ingredient");
            DropTable("dbo.Food");
            DropTable("dbo.UnitOfMeasure");
            DropTable("dbo.FoodItem");
            DropTable("dbo.AsPurchasedItem");
        }
    }
}
