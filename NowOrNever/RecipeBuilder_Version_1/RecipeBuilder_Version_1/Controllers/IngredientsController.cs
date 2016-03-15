using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RecipeBuilder_Version_1.DAL;
using RecipeBuilder_Version_1.Models;
using PagedList;

namespace RecipeBuilder_Version_1.Controllers
{
    public class IngredientsController : Controller
    {
        private RecipeBuilder2Context db = new RecipeBuilder2Context();

        // GET: Ingredients
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            int max = 6;
            int min = 1;
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.FoodSortParm = sortOrder == "Food" ? "food_desc" : "Food";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var ingredients = (from i in db.Ingredients select i).OrderBy(i => i.IngredientName);

            if (!String.IsNullOrEmpty(searchString))
            {
                var sResult = ingredients.Where(m =>
                   m.IngredientName.Contains(searchString)
                   );

                switch (sortOrder)
                {
                    case "name_desc":
                        sResult.OrderByDescending(m => m.IngredientName);
                        break;
                    case "Food":
                        sResult.OrderBy(m => m.Food.FoodName);  //TODO: fix this does not sort
                        break;
                    case "food_desc":
                        sResult.OrderByDescending(m => m.Food.FoodName);  //TODO: fix this does not sort
                        break;
                    default:
                        sResult.OrderBy(m => m.IngredientName);
                        break;
                }

                int childPageSize = max;
                if (sResult.Count() <= childPageSize) { childPageSize = sResult.Count(); }

                int childPageNumber = (page ?? 1);
                if (!sResult.Any())
                {
                    childPageSize = min;
                    return View(sResult.ToPagedList(childPageNumber, childPageSize));
                }

                return View(sResult.ToPagedList(childPageNumber, childPageSize));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    ingredients.OrderByDescending(m => m.IngredientName);
                    break;
                case "Food":
                    ingredients.OrderBy(m => m.Food.FoodName); //TODO: fix this does not sort
                    break;
                case "food_desc":
                    ingredients.OrderByDescending(m => m.Food.FoodName);  //TODO: fix this does not sort
                    break;
                default:
                    ingredients.OrderBy(m => m.IngredientName);
                    break;
            }
            int pageSize = max;
            if (ingredients.Count() <= pageSize) { pageSize = ingredients.Count(); }

            int pageNumber = (page ?? 1);
            if (!ingredients.Any())
            {
                pageSize = min;
                return View(ingredients.ToPagedList(pageNumber, pageSize));
            }
            return View(ingredients.ToPagedList(pageNumber, pageSize));
        }

        // GET: Ingredients/Details/5
        public ActionResult Details(int? id)
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

        // GET: Ingredients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ingredients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IngredientID,IngredientName,UnitQuantity,Preparation")] Ingredient ingredient)
        {
            
            if (ModelState.IsValid)
            {
                db.Ingredients.Add(ingredient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ingredient);
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
        public ActionResult Edit([Bind(Include = "IngredientID,IngredientName,UnitQuantity,Preparation")] Ingredient ingredient)
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
