namespace RecipeBuilder_Version_1.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.Owin;
    using RecipeBuilder_Version_1.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RecipeBuilder_Version_1.DAL.RecipeBuilder2Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(RecipeBuilder_Version_1.DAL.RecipeBuilder2Context context)
        {
            /*if (System.Diagnostics.Debugger.IsAttached == false)
                System.Diagnostics.Debugger.Launch();*/
            var forums = new List<Forum>()
            {
                new Forum { Categories = new List<Category>(), ForumName = "Main"}
            };
            forums.ForEach(s => context.Fora.AddOrUpdate(p => p.ForumName, s));

            InitializeIdentityForEF(context);
            var userManager = new UserManager<Member>(
              new UserStore<Member>(context));

            var members = new List<Member>
            {
                new Member { Email = "sample@email.com",UserName="sample@email.com", FirstName = "Sam", LastName = "Ple", Password = "Password1", NickName = "ABCMouse", DateJoined = DateTime.Parse("2016-01-25"), MemberID = 1, Messages = new List<Message>() },
                new Member { Email = "example@email.com", UserName="example@email.com", FirstName = "Exam", LastName = "Ple", Password = "Password1", NickName = "BCDMouse", DateJoined = DateTime.Parse("2015-05-02"), MemberID = 2, Messages = new List<Message>()},
                new Member { Email = "lonnieteter@email.com",UserName="lonnieteter@email.com", FirstName = "Lonnie", LastName = "Teter", Password = "Password1", NickName = "ChefCode", DateJoined = DateTime.Parse("2014-12-06"), MemberID =3, Messages = new List<Message>() },
                new Member { Email = "parkerdavis@email.com",UserName="parkerdavis@email.com", FirstName = "Parker", LastName = "Davis", Password = "Password1", NickName = "ChefCodejr", DateJoined = DateTime.Parse("2014-06-12"), MemberID =4, Messages = new List<Message>() },
                new Member { Email = "stephaniday@email.com",UserName="stephaniday@email.com",FirstName = "Stephani", LastName = "Day", Password = "Password1", NickName = "MrsChefCode", DateJoined = DateTime.Parse("2013-11-11"), MemberID =5 , Messages = new List<Message>()}
            };
            //Now I save each member by logging them in and out to hash their password using OWIN -LONNIE
            members.ForEach(s => context.Users.AddOrUpdate(p => p.Email, s));
            foreach (var member in members)
            {
                var user = context.Users.SingleOrDefault(u => u.Email == member.Email);
                if (user == null)
                {
                    var result = userManager.Create(member, member.Password);
                    if (result.Succeeded)
                    {
                        InitializeAuthenticationApplyAppCookie(userManager, member);
                    }
                }
            }
            members.ForEach(s => context.Users.AddOrUpdate(p => p.Email, s));
            context.SaveChanges();

            var topics = new List<Topic>
            {
                new Topic {  Description = "All things food", Messages = new List<Message>()},
                new Topic {  Description = "Everything under the sun and beyond", Messages = new List<Message>()},
                new Topic {  Description = "Things don't add up", Messages = new List<Message>()},
                new Topic {  Description = "Post college life", Messages = new List<Message>()},
                new Topic {  Description = "Before they were professionals", Messages = new List<Message>()}
            };
            topics.ForEach(s => context.Topics.AddOrUpdate(p => p.Description, s));
            context.SaveChanges();

            var categories = new List<Category>()
            {
                new Category { ForumID = forums[0].ForumID, Messages = new List<Message>(), Title = "The Future", Description = "Fast-forward to the past, we're going back to the future. "},
                new Category { ForumID = forums[0].ForumID, Messages = new List<Message>(), Title = "Sustainability", Description = "Re-cycle, Re-use, Re-plenish and Re-plant, and make a profit as a by-product. "},
                new Category { ForumID = forums[0].ForumID, Messages = new List<Message>(), Title = "Restaurants", Description =  "We love to talk about local restaurants. "}
            };
            categories.ForEach(s => context.Categories.AddOrUpdate(p => p.Title, s));
            context.SaveChanges();

            var messages = new List<Message>
            {
                new Message { MemberID = members.Single(s => s.Email == "sample@email.com").MemberID,
                    TopicID = topics[0].TopicID, Subject = "I Love Food", Body = "How long you got...", Date = DateTime.Parse("2005-09-01"), Comments = new List<Comment>(), CategoryID = categories[0].CategoryID},

                new Message { MemberID = members.Single(s => s.Email == "example@email.com").MemberID,
                    TopicID = topics[0].TopicID, Subject = "RE:I Love Food", Body = "I Got awhile...", Date = DateTime.Parse("2005-09-02"), CategoryID = categories[0].CategoryID},

                new Message { MemberID = members.Single(s => s.Email == "lonnieteter@email.com").MemberID,
                    TopicID = topics[0].TopicID, Subject = "RE:I Love Food", Body = "I Got awhile too...", Date = DateTime.Parse("2005-09-03"), Comments = new List<Comment>(), CategoryID = categories[0].CategoryID},

                new Message { MemberID = members.Single(s => s.Email == "parkerdavis@email.com").MemberID,
                    TopicID = topics[1].TopicID, Subject = "I Hate Food", Body = "No How long you got...", Date = DateTime.Parse("2005-09-04"), CategoryID = categories[0].CategoryID},

                new Message { MemberID = members.Single(s => s.Email == "stephaniday@email.com").MemberID,
                    TopicID = topics[1].TopicID, Subject = "RE:I Hate Food", Body = "Save it buddy...", Date = DateTime.Parse("2005-09-05"), CategoryID = categories[0].CategoryID},

                new Message { MemberID = members.Single(s => s.Email == "sample@email.com").MemberID,
                    TopicID = topics[2].TopicID, Subject = "I Love Science", Body = "Hey How long you got...", Date = DateTime.Parse("2005-09-06"), CategoryID = categories[0].CategoryID},

                new Message { MemberID = members.Single(s => s.Email == "example@email.com").MemberID,
                    TopicID = topics[3].TopicID, Subject = "I Love Math", Body = "How long do I got..?", Date = DateTime.Parse("2005-09-07"), CategoryID = categories[0].CategoryID},

                new Message { MemberID = members.Single(s => s.Email == "lonnieteter@email.com").MemberID,
                    TopicID = topics[4].TopicID, Subject = "I Love My Career", Body = "I'll tell you how long I got....", Date = DateTime.Parse("2005-09-08"), CategoryID = categories[0].CategoryID},

                new Message { MemberID = members.Single(s => s.Email == "parkerdavis@email.com").MemberID,
                    TopicID = topics[4].TopicID, Subject = "I Loved College", Body = "You Do that...", Date = DateTime.Parse("2005-09-09"), CategoryID = categories[0].CategoryID},

                new Message { MemberID = members.Single(s => s.Email == "stephaniday@email.com").MemberID,
                    TopicID = topics[4].TopicID, Subject = "I Love Science", Body = "I will you just watch..", Date = DateTime.Parse("2005-09-10"), CategoryID = categories[0].CategoryID }
            };
            messages.ForEach(s => context.Messages.AddOrUpdate(p => p.Body, s));

            context.SaveChanges();

            var comments = new List<Comment>()
            {
                new Comment { MessageID = messages[0].MessageID, MemberID = members[2].MemberID, Date = DateTime.Parse("2005-10-01"), Body = "All Day :)" },
                new Comment { MessageID = messages[0].MessageID, MemberID = members[2].MemberID, Date = DateTime.Parse("2005-10-02"), Body = "HellO??" },
                new Comment { MessageID = messages[0].MessageID, MemberID = members[0].MemberID, Date = DateTime.Parse("2005-10-03"), Body = "Sorry I'm Back" },
                new Comment { MessageID = messages[2].MessageID, MemberID = members[1].MemberID, Date = DateTime.Parse("2005-11-01"), Body = "What's up?" },
                new Comment { MessageID = messages[0].MessageID, MemberID = members[0].MemberID, Date = DateTime.Parse("2005-11-02"), Body = "Comment on my own post"}
            };
            comments.ForEach(s => context.Comments.AddOrUpdate(p => p.Body, s));
            context.SaveChanges();

            AddOrUpdate_Comment_Into_Message(context, comments[0].Body, messages[0].Body);
            AddOrUpdate_Comment_Into_Message(context, comments[1].Body, messages[0].Body);
            AddOrUpdate_Comment_Into_Message(context, comments[2].Body, messages[0].Body);
            AddOrUpdate_Comment_Into_Message(context, comments[3].Body, messages[2].Body);
            AddOrUpdate_Comment_Into_Message(context, comments[4].Body, messages[0].Body);



            /* AddOrUpdate_Message_Into_Category(context, messages[0], categories[0].Title);
             AddOrUpdate_Message_Into_Category(context, messages[1], categories[1].Title);
             AddOrUpdate_Message_Into_Category(context, messages[2], categories[2].Title);
             AddOrUpdate_Message_Into_Category(context, messages[3], categories[1].Title);
             AddOrUpdate_Message_Into_Category(context, messages[4], categories[1].Title);
             AddOrUpdate_Message_Into_Category(context, messages[5], categories[1].Title);
             AddOrUpdate_Message_Into_Category(context, messages[6], categories[1].Title);
             AddOrUpdate_Message_Into_Category(context, messages[7], categories[1].Title);
             AddOrUpdate_Message_Into_Category(context, messages[8], categories[1].Title);
             AddOrUpdate_Message_Into_Category(context, messages[9], categories[1].Title);*/

            context.SaveChanges();

            AddOrUpdate_Category_Into_Forum(context, categories[0].Title, forums[0].ForumName);
            AddOrUpdate_Category_Into_Forum(context, categories[1].Title, forums[0].ForumName);
            AddOrUpdate_Category_Into_Forum(context, categories[2].Title, forums[0].ForumName);

            context.SaveChanges();


            var unitOfMeasures = new List<UnitOfMeasure>()
            {
                new UnitOfMeasure { Unit = "Pound", UnitQuantity = 1m},
                new UnitOfMeasure { Unit = "Ounce", UnitQuantity = 1m},
                new UnitOfMeasure { Unit = "Gallon", UnitQuantity = 1m},
                new UnitOfMeasure { Unit = "Half-Gallon", UnitQuantity = 1m},
                new UnitOfMeasure { Unit = "Quart", UnitQuantity = 1m},
                new UnitOfMeasure { Unit = "Pint", UnitQuantity = 1m},
                new UnitOfMeasure { Unit = "Cup", UnitQuantity = 1m},
                new UnitOfMeasure { Unit = "Fluid-Ounce", UnitQuantity = 1m},
                new UnitOfMeasure { Unit = "Each", UnitQuantity = 1m},
                new UnitOfMeasure { Unit = "Table-Spoon", UnitQuantity = 1m},
                new UnitOfMeasure { Unit = "Tea-Spoon", UnitQuantity = 1m}
            };
            unitOfMeasures.ForEach(s => context.UnitOfMeasures.AddOrUpdate(p => p.Unit, s));
            context.SaveChanges();

            var foodItems = new List<FoodItem>()
            {
                new FoodItem { FoodName = "Apple", IndividualAsPurchasedWeight = 0.5m,  PotentiallyHazardous = false, Specification = "Fresh", YieldPercentage = 1},
                new FoodItem { FoodName = "Orange", IndividualAsPurchasedWeight = 0.5m,  PotentiallyHazardous = false, Specification = "Fresh", YieldPercentage = 1},
                new FoodItem { FoodName = "Lemon", IndividualAsPurchasedWeight = 0.5m,  PotentiallyHazardous = false, Specification = "Fresh", YieldPercentage = 1},
                new FoodItem { FoodName = "Tomato", IndividualAsPurchasedWeight = 0.5m,  PotentiallyHazardous = false, Specification = "Fresh", YieldPercentage = 1},
                new FoodItem { FoodName = "Lettuce", IndividualAsPurchasedWeight = 1m,  PotentiallyHazardous = false, Specification = "Head of", YieldPercentage = 1},
                new FoodItem { FoodName = "Bacon", IndividualAsPurchasedWeight = 4m,  PotentiallyHazardous = true, Specification = "Cured", YieldPercentage = 1}
            };
            foodItems.ForEach(s => context.FoodItems.AddOrUpdate(p => p.FoodName, s));
            context.SaveChanges();

            var asPurchasedItems = new List<AsPurchasedItem>()
            {
                new AsPurchasedItem { AsPurchasedName = "fooditem1", FoodItem = foodItems[0], AsPurchasedUnitQuantity = 50, UnitOfMeasure= unitOfMeasures[0], FoodItemQuantity = 1},
                new AsPurchasedItem { AsPurchasedName = "fooditem2", FoodItem = foodItems[1], AsPurchasedUnitQuantity = 50, UnitOfMeasure= unitOfMeasures[0], FoodItemQuantity = 1},
                new AsPurchasedItem { AsPurchasedName = "fooditem3", FoodItem = foodItems[2], AsPurchasedUnitQuantity = 50, UnitOfMeasure= unitOfMeasures[0], FoodItemQuantity = 1},
                new AsPurchasedItem { AsPurchasedName = "fooditem4", FoodItem = foodItems[3], AsPurchasedUnitQuantity = 50, UnitOfMeasure= unitOfMeasures[0], FoodItemQuantity = 1},
                new AsPurchasedItem { AsPurchasedName = "fooditem5", FoodItem = foodItems[4], AsPurchasedUnitQuantity = 50, UnitOfMeasure= unitOfMeasures[0], FoodItemQuantity = 1},
                new AsPurchasedItem { AsPurchasedName = "fooditem6", FoodItem = foodItems[5], AsPurchasedUnitQuantity = 50, UnitOfMeasure= unitOfMeasures[0], FoodItemQuantity = 1}
            };
            asPurchasedItems.ForEach(s => context.AsPurchasedItems.AddOrUpdate(p => p.AsPurchasedName, s));
            context.SaveChanges();

            var packages = new List<Package>()
            {
                new Package { AsPurchasedItem = asPurchasedItems[0], PackageCost = 100, VendorCode = "XYZ123", QRCode ="abc123"},
                new Package { AsPurchasedItem = asPurchasedItems[1], PackageCost = 100, VendorCode = "XYZ123", QRCode ="abc124"},
                new Package { AsPurchasedItem = asPurchasedItems[2], PackageCost = 100, VendorCode = "XYZ123", QRCode ="abc125"},
                new Package { AsPurchasedItem = asPurchasedItems[3], PackageCost = 100, VendorCode = "XYZ123", QRCode ="abc126"},
                new Package { AsPurchasedItem = asPurchasedItems[4], PackageCost = 100, VendorCode = "XYZ123", QRCode ="abc127"},
                new Package { AsPurchasedItem = asPurchasedItems[5], PackageCost = 100, VendorCode = "XYZ123", QRCode ="abc128"},
            };
            packages.ForEach(s => context.Packages.AddOrUpdate(p => p.QRCode, s));
            context.SaveChanges();

/******************************************* Schema Extention ******************************************************************************************************************************************/
            var foods = new List<Food>()
            {
                new Food { FoodName = "Apple", IndividualAsPurchasedWeight = 0.5m,  PotentiallyHazardous = false, Specification = "Fresh", YieldPercentage = 1},
                new Food { FoodName = "Orange", IndividualAsPurchasedWeight = 0.5m,  PotentiallyHazardous = false, Specification = "Fresh", YieldPercentage = 1},
                new Food { FoodName = "Lemon", IndividualAsPurchasedWeight = 0.5m,  PotentiallyHazardous = false, Specification = "Fresh", YieldPercentage = 1},
                new Food { FoodName = "Tomato", IndividualAsPurchasedWeight = 0.5m,  PotentiallyHazardous = false, Specification = "Fresh", YieldPercentage = 1},
                new Food { FoodName = "Lettuce", IndividualAsPurchasedWeight = 1m,  PotentiallyHazardous = false, Specification = "Head of", YieldPercentage = 1},
                new Food { FoodName = "Bacon", IndividualAsPurchasedWeight = 4m,  PotentiallyHazardous = true, Specification = "Cured", YieldPercentage = 1}
            };
            foods.ForEach(s => context.Foods.AddOrUpdate(p => p.FoodName, s));
            context.SaveChanges();

            var recipes = new List<Recipe>()
            {
                new Recipe { MenuItemQuantity = 1, RecipeCost = 3.00m, RecipeName = "BLT", Ingredients = new List<Ingredient>()},
                new Recipe { MenuItemQuantity = 1, RecipeCost = 1.50m, RecipeName = "Citrus Salad", Ingredients = new List<Ingredient>()}
            };
            recipes.ForEach(s => context.Recipes.AddOrUpdate(p => p.RecipeName, s));
            context.SaveChanges();

            var ingredients = new List<Ingredient>()
            {
                new Ingredient {   Food = foods[5], UnitOfMeasure = unitOfMeasures[0], UnitQuantity = 0.5m, IngredientName = "Crispy Bacon", Preparation = "Render", Recipes = new List<Recipe>()},
                new Ingredient {   Food = foods[4], UnitOfMeasure = unitOfMeasures[0], UnitQuantity = 0.5m, IngredientName = "Sliced Tomato", Preparation = "Slice", Recipes = new List<Recipe>()},
                new Ingredient {   Food = foods[3], UnitOfMeasure = unitOfMeasures[0], UnitQuantity = 0.5m, IngredientName = "Crisp Lettuce", Preparation = "Shred", Recipes = new List<Recipe>()},
                new Ingredient {   Food = foods[2], UnitOfMeasure = unitOfMeasures[1], UnitQuantity = 12.5m, IngredientName = "Fresh Lemon", Preparation = "Cut in half & Squeeze", Recipes = new List<Recipe>()},
                new Ingredient {   Food = foods[1], UnitOfMeasure = unitOfMeasures[1], UnitQuantity = 10.5m, IngredientName = "Fresh Orange", Preparation = "Peel & Slice", Recipes = new List<Recipe>()},
                new Ingredient {   Food = foods[0], UnitOfMeasure = unitOfMeasures[1], UnitQuantity = 10.5m, IngredientName = "Fresh Apple", Preparation = "Peel & Slice", Recipes = new List<Recipe>()}
            };
            ingredients.ForEach(s => context.Ingredients.AddOrUpdate(p => p.IngredientName, s));
            context.SaveChanges();

            
            //var recipes = new List<Recipe>
            //{
            //    new Recipe { MenuItemQuantity = 1, RecipeCost = 3.00m, RecipeName = "BLT", Ingredients = new List<Ingredient>()
            //      DepartmentID = departments.Single( s => s.Name == "Engineering").DepartmentID,
            //      Instructors = new List<Instructor>() 
            //    },
            //}

            AddOrUpdateIngredient(context, "BLT", "Crispy Bacon");
            AddOrUpdateIngredient(context, "BLT", "Sliced Tomato");
            AddOrUpdateIngredient(context, "BLT", "Crisp Lettuce");
            AddOrUpdateIngredient(context, "Citrus Salad", "Fresh Lemon");
            AddOrUpdateIngredient(context, "Citrus Salad", "Fresh Orange");
            AddOrUpdateIngredient(context, "Citrus Salad", "Fresh Apple");

            var menuItems = new List<MenuItem>()
            {
                new MenuItem { MenuItemName = "BLT", RecipeID = recipes.Single(s => s.RecipeName == "BLT").RecipeID },
                 new MenuItem { MenuItemName = "Citrus Salad", RecipeID = recipes.Single(s => s.RecipeName == "Citrus Salad").RecipeID}
            };
            menuItems.ForEach(s => context.MenuItems.AddOrUpdate(p => p.MenuItemName, s));
            context.SaveChanges();

            var menuMeals = new List<MenuMeal>()
            {
                new MenuMeal { MenuMealName = "BLT & Citrus Salad"}
            };
            menuMeals.ForEach(s => context.MenuMeals.AddOrUpdate(p => p.MenuMealName, s));
            context.SaveChanges();

            AddOrUpdate_MenuMeal_With_MenuItem(context, "BLT & Citrus Salad", "BLT");
            AddOrUpdate_MenuMeal_With_MenuItem(context, "BLT & Citrus Salad", "Citrus Salad");

            var menus = new List<Menu>()
            {
                new Menu() {  MenuName= "Dinner", MenuDesigner = "Lonnie", DateCreated = DateTime.Now }
            };
            menus.ForEach(s => context.Menus.AddOrUpdate(p => p.MenuName, s));
            context.SaveChanges();

            AddOrUpdate_MENU_With_MenuItem(context, "Dinner", "BLT");
            AddOrUpdate_MENU_With_MenuItem(context, "Dinner", "Citrus Salad");
            AddOrUpdate_MENU_With_MENUMEAL(context, "Dinner", "BLT & Citrus Salad");
           

        }
        void AddOrUpdateIngredient(RecipeBuilder_Version_1.DAL.RecipeBuilder2Context context,
                                                                          string recipeName,
                                                                      string ingredientName)
        {
            var recipe = context.Recipes.SingleOrDefault(r => r.RecipeName == recipeName);
            var ingredient = recipe.Ingredients.SingleOrDefault(i => i.IngredientName == ingredientName);
            if (ingredient == null)
                recipe.Ingredients.Add(context.Ingredients.Single(i => i.IngredientName == ingredientName));
        }
        void AddOrUpdate_MenuMeal_With_MenuItem(RecipeBuilder_Version_1.DAL.RecipeBuilder2Context context,
                                                                          string menuMealName,
                                                                      string menuItemName)
        {
            var menuMeal = context.MenuMeals.SingleOrDefault(mm => mm.MenuMealName == menuMealName);
            if (menuMeal == null)
                throw new NullReferenceException("menuMeal NOT found!!");
            var menuItem = menuMeal.MenuItems.Where(mi => mi.MenuItemName == menuItemName).FirstOrDefault();
            if (menuItem == null)
                menuMeal.MenuItems.Add(context.MenuItems.Single(mi => mi.MenuItemName == menuItemName));
        }
        void AddOrUpdate_MENU_With_MenuItem(RecipeBuilder_Version_1.DAL.RecipeBuilder2Context context,
                                                                         string menuName,
                                                                     string menuItemName)
        {
            var menu = context.Menus.SingleOrDefault(mm => mm.MenuName == menuName);
            var menuItem = menu.MenuItems.SingleOrDefault(mi => mi.MenuItemName == menuItemName);
            if (menuItem == null)
                menu.MenuItems.Add(context.MenuItems.Single(mi => mi.MenuItemName == menuItemName));
        }
        void AddOrUpdate_MENU_With_MENUMEAL(RecipeBuilder_Version_1.DAL.RecipeBuilder2Context context,
                                                                        string menuName,
                                                                    string menuMealName)
        {
            var menu = context.Menus.SingleOrDefault(mm => mm.MenuName == menuName);
            if (menu == null)
                throw new NullReferenceException("menu NOT Found!!");
            var menuMeal = menu.MenuMeals.SingleOrDefault(mi => mi.MenuMealName == menuMealName);
            if (menuMeal == null)
                menu.MenuMeals.Add(context.MenuMeals.Single(mi => mi.MenuMealName == menuMealName));
        }

        void AddOrUpdate_Category_Into_Forum(RecipeBuilder_Version_1.DAL.RecipeBuilder2Context context,
                                                                         string categoryTitle,
                                                                     string forumName)
        {
            var forum = context.Fora.SingleOrDefault(f => f.ForumName == forumName);
            var category = forum.Categories.SingleOrDefault(c => c.Title == categoryTitle);
            if (category == null)
                forum.Categories.Add(context.Categories.Single(ct => ct.Title == categoryTitle));
        }
        void AddOrUpdate_Comment_Into_Message(RecipeBuilder_Version_1.DAL.RecipeBuilder2Context context,
                                                                          string commentBody,
                                                                      string messageBody)
        {
            var message = context.Messages.SingleOrDefault(m => m.Body == messageBody);
            var comment = message.Comments.SingleOrDefault(c => c.Body == commentBody);
            if (comment == null)
                message.Comments.Add(context.Comments.Single(ct => ct.Body == commentBody));
        }
        void AddOrUpdate_Message_Into_Category(RecipeBuilder_Version_1.DAL.RecipeBuilder2Context context,
                                                                           Message message,
                                                                      string categoryTitle)
        {
            var category = context.Categories.SingleOrDefault(c => c.Title == categoryTitle);
            if (category == null)
            {
                throw new NullReferenceException("category does NOT exist!!");
            }
            var messageByDate = category.Messages.Where(m => m.Date == message.Date);
            if (messageByDate.Count() > 1)
            {
                var single = messageByDate.SingleOrDefault(s => s.MemberID == message.MemberID);
                if (single == null)
                {
                    category.Messages.Add(context.Messages.Single(mes => mes.MemberID == message.MemberID));
                    context.SaveChanges();
                }
            }

            if (messageByDate == null)
            {
                category.Messages.Add(context.Messages.Single(mes => mes.MemberID == message.MemberID));
                context.SaveChanges();
            }
        }

        private static void InitializeAuthenticationApplyAppCookie(UserManager<Member> userManager,
            Member member)
        {
            var identity = userManager.CreateIdentity(
               member, DefaultAuthenticationTypes.ApplicationCookie);

            IOwinContext octx = new OwinContext();
            octx.Request.Context.Authentication.SignIn(identity);
            octx.Request.Context.Authentication.SignOut("ApplicationCookie");
        }
        public static void InitializeIdentityForEF(RecipeBuilder_Version_1.DAL.RecipeBuilder2Context db)
        {
            var userManager = new UserManager<Member>(
              new UserStore<Member>(db));

            var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(db));

            userManager.UserValidator = new UserValidator<Member>(userManager) { AllowOnlyAlphanumericUserNames = false };
            const string userName = "admin@admin.com";
            const string password = "Admin@123456";
            const string roleName = "Admin";

            //Create Role "Admin" if it does not exist
            var role = roleManager.FindByName(roleName);
            if (role == null)
            {
                role = new IdentityRole(roleName);
                var roleresult = roleManager.Create(role);
            }

            var member = userManager.FindByName(userName);
            if (member == null)
            {
                member = new Member { UserName = userName, Email = userName, NickName = roleName, FirstName = roleName, LastName = roleName, DateJoined = DateTime.Parse("2000-01-01") };
                var result = userManager.Create(member, password);
                InitializeAuthenticationApplyAppCookie(userManager, member);
                result = userManager.SetLockoutEnabled(member.Id, false);
            }

            // Add user admin to Role Admin if not already added
            var rolesForUser = userManager.GetRoles(member.Id);
            if (!rolesForUser.Contains(role.Name))
            {
                var result = userManager.AddToRole(member.Id, role.Name);
            }
        }

    }
    
}
