using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipeBuilder_Version_1.Models
{
    public class AsPurchasedItem
    {
        //Example: '150' seperate '16.5' 'fluid ounce' bottles of 'Catsup'
        public virtual int AsPurchasedItemID { get; set; }

        public virtual FoodItem APFoodItem { get; set; } //'Catsup'

        public virtual decimal APUnitAmount { get; set; } //'16.5'

        public virtual UnitOfMeasure APUnit { get; set; } //'fluid ounce'

        public virtual int APFoodItemQuantity { get; set; }   //'150'
     
    }
}