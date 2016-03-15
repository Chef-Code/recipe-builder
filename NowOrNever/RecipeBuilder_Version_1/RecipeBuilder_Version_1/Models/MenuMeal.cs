using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipeBuilder_Version_1.Models
{
    public class MenuMeal
    {
        public MenuMeal()
        {
            this.MenuItems = new HashSet<MenuItem>();
        }
        public int MenuMealID { get; set; }
        public string MenuMealName { get; set; }

        public Nullable<int> MenuID { get; set; }
        public virtual Menu Menu { get; set; }
        public virtual ICollection<MenuItem> MenuItems { get; set; }
    }
}