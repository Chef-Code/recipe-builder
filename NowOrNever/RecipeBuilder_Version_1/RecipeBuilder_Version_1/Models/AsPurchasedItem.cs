using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipeBuilder_Version_1.Models
{
    public class AsPurchasedItem
    {
        //Example: '150' seperate '16.5' 'fluid ounce(s)' bottles of 'Catsup'
        public AsPurchasedItem()
        {
            this.FoodItem = new FoodItem();
            this.UnitOfMeasure = new UnitOfMeasure();
        }
        public int AsPurchasedItemID { get; set; }
        public string AsPurchasedName { get; set; }
       
        public int FoodItemQuantity { get; set; }   //'150'
        public decimal AsPurchasedUnitQuantity { get; set; } //'16.5'

        //public int UnitOfMeasureID { get; set; }        
        public virtual UnitOfMeasure UnitOfMeasure { get; set; } //'fluid ounce(s)'

        //public int FoodItemID { get; set; }
        public virtual FoodItem FoodItem { get; set; } //'Catsup'

       /* public int PackageID { get; set; }
        public virtual Package Package { get; set; }*/
     
    }
}