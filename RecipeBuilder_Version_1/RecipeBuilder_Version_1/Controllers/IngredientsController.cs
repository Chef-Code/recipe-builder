using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RecipeBuilder_Version_1.Models;

namespace RecipeBuilder_Version_1.Controllers
{
    public class IngredientsController : Controller
    {
        private RecipeBuilder_Version_1Context db = new RecipeBuilder_Version_1Context();

        // GET: Ingredients
        public ActionResult Index()
        {
           
                return View(GetRecipesAndIngredients(0));
            
        }

        // GET: Ingredients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           // IngredientViewModel ingredient = GetRecipesAndIngredients(id).FirstOrDefault();
            IngredientViewModel ingredVM = GetIngredientAndRecipe(id);
            if (ingredVM == null)
            {
                return HttpNotFound();
            }
            return View(ingredVM);
        }

        // GET: Ingredients/Create
        public ActionResult Create()
        {
            ViewBag.RecipeNames = new SelectList(db.Recipes.OrderBy(r => r.RecipeName), "RecipeID", "RecipeName");
            return View();
        }

        // POST: Ingredients/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IngredientID,IngredientName,UnitQuantity,Preparation,RecipeItem, RecipeNames")] IngredientViewModel ingredVM, int RecipeNames)
        {
            if (ModelState.IsValid)
            {

                Recipe recipe = (from r in db.Recipes
                                 where r.RecipeID == RecipeNames
                                 select r).FirstOrDefault();

                //TODO: Modify the view allow to enter a new RecipeName
                if (recipe == null)
                {
                    recipe = new Recipe() { RecipeName = ingredVM.RecipeItem.RecipeName };
                    db.Recipes.Add(recipe);
                }
                Ingredient ingredient = new Ingredient()
                {

                    UnitQuantity = ingredVM.UnitQuantity,
                    IngredientID = ingredVM.IngredientID,
                    IngredientName = ingredVM.IngredientName,
                    Preparation = ingredVM.Preparation,
                    RecipeID = recipe.RecipeID

                };

                db.Entry(ingredient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RecipeNames = new SelectList(db.Recipes.OrderBy(r => r.RecipeName), "RecipeID", "RecipeName");

            return View(ingredVM);
        }

 
        // GET: Ingredients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingredient ingredient = db.Ingredients.Find(id);
            if (ingredient == null)
            {
                return HttpNotFound();
            }
            return View(ingredient);
        }

        // POST: Ingredients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IngredientID,RecipeID,IngredientName,UnitQuantity,Preparation")] Ingredient ingredient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ingredient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ingredient);
        }

        // GET: Ingredients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingredient ingredient = db.Ingredients.Find(id);
            if (ingredient == null)
            {
                return HttpNotFound();
            }
            return View(ingredient);
        }


        // POST: Ingredients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ingredient ingredient = db.Ingredients.Find(id);
            db.Ingredients.Remove(ingredient);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET: Ingredient/Search
        [HttpGet]
        public ActionResult Search()
        {
            return View();
        }
        //POST: Ingredient/Search
        [HttpPost]
        public ActionResult Search(string searchTerm)
        {
            List<IngredientViewModel> ingredVMs = new List<IngredientViewModel>();
            var ingreds = (from i in db.Ingredients                         
                           where i.IngredientName.Contains(searchTerm)
                           select i).ToList();

            foreach(var i in ingreds)
            {
                var recipe = (from r in db.Recipes
                              where r.RecipeID == i.RecipeID
                              select r).FirstOrDefault();

                ingredVMs.Add( new IngredientViewModel
                {
                    UnitQuantity = i.UnitQuantity,
                    IngredientID = i.IngredientID,
                    IngredientName = i.IngredientName,
                    Preparation = i.Preparation,
                    RecipeItem = recipe
                });
            }
                        
          if(ingredVMs.Count == 1)
          {
              return View("Details", ingredVMs[0]);
          }
          else
          {
              return View("Index", ingredVMs);
          }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private List<IngredientViewModel> GetRecipesAndIngredients(int? ingredID)
        {
            var ingredients = new List<IngredientViewModel>();
           
            var recipes = from recipe in db.Recipes.Include("Ingredients")
                          select recipe;

         
            foreach (Recipe r in recipes)
            {
                foreach (Ingredient i in r.Ingredients)
                {
                    if (i.IngredientID == ingredID || 0 == ingredID)
                    {
                        var ingredVm = new IngredientViewModel();
                        ingredVm.IngredientName = i.IngredientName;
                        ingredVm.UnitQuantity = i.UnitQuantity;
                        ingredVm.Preparation = i.Preparation;
                        ingredVm.IngredientID = i.IngredientID;
                        ingredVm.RecipeItem = r;
                        ingredients.Add(ingredVm);
                    }
                }
            }

            return ingredients;
        }

        private IngredientViewModel GetIngredientAndRecipe(int? ingredID)
        {
            var ingredVM = (from i in db.Ingredients
                            join r in db.Recipes on i.RecipeID equals r.RecipeID
                            where i.IngredientID == ingredID
                           select new IngredientViewModel { 
                               IngredientID = r.RecipeID,
                               IngredientName = r.RecipeName,
                               RecipeItem = r
                           }).FirstOrDefault();


            return ingredVM;
        }
    }
}
