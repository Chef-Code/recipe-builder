using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipeBuilder_Version_1.Models
{
    public class FoodItem
    {
        public virtual int FoodItemID { get; set; }
        public virtual string FoodName { get; set; }
    
        //EP = Edible Portion
        public virtual decimal EPYieldPercentage { get; set; }
        //Potentially Hazardous Foods
        public virtual bool PotHazFood { get; set; }

        /*public void ShelfLife(DateTime expiration)
        {
            //TODO: implement how to determine the food items shelf life
                    
            /*TODO: Determine: 
             * 1. Should this method be part of the FoodItem Class?
             * 2. What should the data type be?
               3. Should this return a date or be an extension
        }*/

    }
}