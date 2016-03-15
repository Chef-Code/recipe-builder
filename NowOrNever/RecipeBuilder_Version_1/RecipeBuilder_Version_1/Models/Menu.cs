using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipeBuilder_Version_1.Models
{
    public class Menu
    {
        public Menu()
        {
            this.MenuItems = new HashSet<MenuItem>();
            this.MenuMeals = new HashSet<MenuMeal>();
        }
        public int MenuID { get; set; }
        public string MenuName { get; set; }
        public string MenuDesigner { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual ICollection<MenuMeal> MenuMeals { get; set; }
        public virtual ICollection<MenuItem> MenuItems { get; set; }                                                                           
    }
}