using RecipeBuilder_Version_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecipeBuilder_Version_1.Controllers
{
    public class MenuController : Controller
    {
        Menu menu = new Menu();

        public MenuController() 
        {
           
        }
        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Inventory()
        {
            ViewBag.Heading = "My awesome Heading";
            List<Ingredient> ingreds = menu.Recipes[0].Ingredients;
            {
                
            }

            return View(ingreds);
        }
    }
}